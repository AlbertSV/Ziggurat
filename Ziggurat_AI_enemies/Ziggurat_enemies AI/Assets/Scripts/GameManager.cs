using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

    [Tooltip("Unit Move Speed"), SerializeField, Range(0.01f, 0.1f)] public float unitSpeed = 0.01f;
    [Tooltip("Target range for units"), SerializeField, Range(1f, 20f)] public float targetRange = 5f;

    [SerializeField] public GameObject _redUnitPanel;
    [SerializeField] public GameObject _blueUnitPanel;
    [SerializeField] public GameObject _greenUnitPanel;
    [SerializeField] public GameObject _unitButton;

    [SerializeField] public GameObject _redZigguratPanel;
    [SerializeField] public GameObject _greenZigguratPanel;
    [SerializeField] public GameObject _blueZigguratPanel;


    private void Awake()
    {
        Manager = this;
    }
}
