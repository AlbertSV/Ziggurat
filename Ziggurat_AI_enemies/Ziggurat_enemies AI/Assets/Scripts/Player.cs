using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ziggurat
{
    public class Player : MonoBehaviour
    {
        private PlayerControl playerMoves;

        [Tooltip("Player Rotation Speed"), SerializeField, Range(0.1f, 1)] private float rotationSpeed = 0.5f;
        [Tooltip("Player Move Speed"), SerializeField, Range(0.1f, 100f)] private float playerSpeed = 30f;
        [Tooltip("Max height for camera move"), SerializeField] private float maxHeight = 30f;
        [Tooltip("Min height for camera move"), SerializeField] private float minHeight = 1f;
        [Tooltip("Height change step size"), SerializeField] private float stepSize = 1f;
        [Tooltip("Zoom speed change"), SerializeField] private float zoomSpeed = 1f;

        private Vector3 moveInput;
        private Vector3 targetPosition;
        private float zoomHeight;

        private void Awake()
        {
            playerMoves = new PlayerControl();
        }

        private void OnEnable()
        {
            zoomHeight = transform.localPosition.y;

            playerMoves.Player.Rotation.performed += PlayerRotation;
            playerMoves.Player.Zoom.performed += ZoomMove;
            playerMoves.Player.Enable();
        }

        private void Update()
        {
            UpdateZoomPosition();
            GetKeyInput();
            Move();
        }

        private void OnDisable()
        {
            playerMoves.Player.Rotation.performed -= PlayerRotation;
            playerMoves.Player.Zoom.performed -= ZoomMove;
            playerMoves.Player.Disable();
        }

        private void GetKeyInput()
        {
            moveInput = playerMoves.Player.Move.ReadValue<Vector2>().x * GetCameraRight() + playerMoves.Player.Move.ReadValue<Vector2>().y * GetCameraForward();
            moveInput = moveInput.normalized;

            targetPosition += moveInput;
        }

        private Vector3 GetCameraForward()
        {
            Vector3 forward = transform.forward;
            forward.y = 0f;
            return forward;
        }

        private Vector3 GetCameraRight()
        {
            Vector3 right = transform.right;
            right.y = 0f;
            return right;
        }

        private void Move()
        {
            transform.position += moveInput * playerSpeed * Time.deltaTime ;
        }

        private void PlayerRotation(InputAction.CallbackContext inputValue)
        {
            if (!Mouse.current.middleButton.isPressed)
                return;
            float value = inputValue.ReadValue<Vector2>().x;

            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, value * rotationSpeed + transform.eulerAngles.y, transform.eulerAngles.z);
        }


        private void ZoomMove(InputAction.CallbackContext inputValue)
        {
            float value = -inputValue.ReadValue<Vector2>().y / 100f;

            zoomHeight = transform.localPosition.y + value * stepSize;

            if (zoomHeight < minHeight)
                zoomHeight = minHeight;
            else if (zoomHeight > maxHeight)
                zoomHeight = maxHeight;
        }

        private void UpdateZoomPosition()
        {
            Vector3 targetZoom = new Vector3(transform.localPosition.x, zoomHeight, transform.localPosition.z);

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetZoom, Time.deltaTime * zoomSpeed);
        }
    }
}