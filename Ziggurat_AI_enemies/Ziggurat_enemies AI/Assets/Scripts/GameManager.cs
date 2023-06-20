using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

    [Tooltip("Unit Move Speed"), SerializeField, Range(0.01f, 0.1f)] public float _unitSpeed = 0.01f;
    [Tooltip("Target range for units"), SerializeField, Range(1f, 20f)] public float _targetRange = 5f;
    [Tooltip("Radius for enemy spotted"), SerializeField, Range(1f, 10f)] public float _FOVRange = 5f;
    [Tooltip("Radius for attack"), SerializeField, Range(1f, 5f)] public float _attackRange = 1f;
    [Tooltip("Unit health"), SerializeField, Range(1f, 5f)] public float _unitHealth = 50f;
    [Tooltip("Unit fast attack damage"), SerializeField, Range(1f, 5f)] public float _fastDamage = 10f;

    [SerializeField] public GameObject _redUnitPanel;
    [SerializeField] public GameObject _blueUnitPanel;
    [SerializeField] public GameObject _greenUnitPanel;
    [SerializeField] public GameObject _unitButton;
    [SerializeField] public Transform _onePoint;
    //[SerializeField] public Transform _twoPoint;
    //[SerializeField] public Transform _threePoint;

    [SerializeField] public GameObject _redZigguratPanel;
    [SerializeField] public GameObject _greenZigguratPanel;
    [SerializeField] public GameObject _blueZigguratPanel;


    private void Awake()
    {
        Manager = this;
    }
}
