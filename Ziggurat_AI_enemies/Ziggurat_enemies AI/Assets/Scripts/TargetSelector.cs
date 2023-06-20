using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Ziggurat
{
    public class TargetSelector : MonoBehaviour
    {
        [SerializeField] private GameObject _targetPoint;

        private ZigguratControl _zigguratControl;
        private UnitControl _unitControl;
        private ZigguratControl _zigguratTarget;
        private UnitControl _unitTarget;
        private GameObject _hittedObject;
        private GameObject _targetObject = null;

        private Camera _camera;
        private Ray _ray;
        private bool _selected = false;
        private bool _isZigPanelOpen = false;
        private bool _isUnitPanelOpen = false;

        void Awake()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            TargetRay();
        }

        //looking for the object on mouse click
        private void TargetRay()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out RaycastHit hit))
                {
        

                    if (FindObjectOfType<SelectedTarget>() != null)
                    {
                        _targetObject = FindObjectOfType<SelectedTarget>().gameObject.transform.parent.gameObject;

                        if (_targetObject.GetComponent<ZigguratControl>() != null)
                        {
                            _zigguratTarget = _targetObject.GetComponent<ZigguratControl>();
                        }
                        if (_targetObject.GetComponent<UnitControl>() != null)
                        {
                            _unitTarget = _targetObject.GetComponent<UnitControl>();
                        }
                    }

                    _hittedObject = hit.collider.gameObject;

                    //unit or ziggurat
                    if (_hittedObject.GetComponent<ZigguratControl>() != null)
                    {
                        _zigguratControl = _hittedObject.GetComponent<ZigguratControl>();
                    }
                    if (_hittedObject.GetComponent<UnitControl>() != null)
                    {
                        _unitControl = _hittedObject.GetComponent<UnitControl>();
                    }


                    //adding button and panel to the scene
                    if (EventSystem.current.currentSelectedGameObject != null)
                    {
                        Debug.Log("Panel");
                    }
                    else if (_hittedObject.GetComponent<Gate>() != null)
                    {
                        DestroySelectedPoint(_targetObject);
                        
                        AddPointToTarget(_hittedObject, new Vector3(_hittedObject.transform.position.x, _hittedObject.transform.position.y + 9f,
                                _hittedObject.transform.position.z), new Vector3(15f, 0.1f, 15f));
                        _zigguratControl.PanelButtonControl(_hittedObject);
                    }
                    else if (_hittedObject.GetComponent<Unit>() != null)
                    {
                        DestroySelectedPoint(_hittedObject);

                        AddPointToTarget(_hittedObject, _hittedObject.transform.position, new Vector3(3f, 0.1f, 3f));
                        _unitControl.PanelButtonControl(_hittedObject);
                    }
                    else
                    {
                        DestroySelectedPoint(_hittedObject);
                    }
                }
            }
        }

        //showing the pointed target
        private void AddPointToTarget(GameObject hittedObject, Vector3 spawnPosition, Vector3 scale)
        {
            _targetPoint.transform.localScale = scale;
            var target = Instantiate(_targetPoint, spawnPosition, transform.rotation, hittedObject.transform);
            _selected = true;
        }

        //clearing the pointed target
        private void DestroySelectedPoint(GameObject hitted)
        {
            if (_selected)
            {
                _selected = false;
                var allSelected = FindObjectsOfType<SelectedTarget>();
                foreach (SelectedTarget selected in allSelected)
                {
                    Destroy(selected.gameObject);
                }

                if (hitted.GetComponent<Button>() == null)
                {
                    if (_unitTarget != null)
                    {
                        _unitTarget.UnitOpenButton.SetActive(false);
                        _unitTarget.SetPanelColor().SetActive(false);
                        _unitTarget.SetPanelColor().transform.localScale = new Vector3(0f, 0f, 0f);
                        _isUnitPanelOpen = false;
                    }
                    if (_zigguratTarget != null)
                    {
                        _zigguratTarget.ZigguratOpenButton.SetActive(false);
                        _zigguratTarget.SetPanelColor().SetActive(false);
                        _zigguratTarget.SetPanelColor().transform.localScale = new Vector3(0f, 0f, 0f);
                        _isZigPanelOpen = false;
                    }
                }
            }
        }

        public void SetPanelColor()
        {
            var targetObject = FindObjectOfType<SelectedTarget>().gameObject.transform.parent.gameObject;
           

            if (_zigguratControl != null && targetObject.GetComponent<Gate>() != null)
            {
                var _zigguratPanel = _zigguratControl.SetPanelColor();
                PanelColorActive(_zigguratPanel, _isZigPanelOpen);
                _isZigPanelOpen = !_isZigPanelOpen;
            }
            else if (_unitControl != null && targetObject.GetComponent<Unit>() != null)
            {
                var _unitPanelColor = _unitControl.SetPanelColor();
                PanelColorActive(_unitPanelColor, _isUnitPanelOpen);
                _isUnitPanelOpen = !_isUnitPanelOpen;
            }
            
        }

        private void PanelColorActive(GameObject panel, bool isOpen)
        {
            Animator animator = panel.GetComponent<Animator>();

            if (panel != null && isOpen == false)
            {

                panel.SetActive(true);
                animator.SetBool("Open", true);
                isOpen = true;
            }
            else if (panel != null && isOpen == true)
            {
                animator.SetBool("Open", false);
                StartCoroutine(WaitForAnimation(panel));
                isOpen = false;
            }
        }

        private IEnumerator WaitForAnimation(GameObject panel)
        {
            yield return new WaitForSeconds(1f);
            panel.SetActive(false);
        }
    }
}
