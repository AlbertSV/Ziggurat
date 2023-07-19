using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class GameManager : MonoBehaviour
    {
        //public static GameManager Manager;

        [SerializeField] public GameObject _redUnitPanel;
        [SerializeField] public GameObject _blueUnitPanel;
        [SerializeField] public GameObject _greenUnitPanel;
        [SerializeField] public GameObject _unitButton;

        [SerializeField] public GameObject _redZigguratPanel;
        [SerializeField] public GameObject _greenZigguratPanel;
        [SerializeField] public GameObject _blueZigguratPanel;

        [Header("Parameters Settings")]
        [Tooltip("Unit Move Speed"), SerializeField, Range(0.01f, 0.05f)] private float _unitSpeed = 0.01f;
        [Tooltip("Target range for units"), SerializeField, Range(1f, 20f)] private float _targetRange = 5f;
        [Tooltip("Radius for enemy spotted"), SerializeField, Range(1f, 10f)] private float _FOVRange = 5f;
        [Tooltip("Radius for attack"), SerializeField, Range(1f, 5f)] private float _attackRange = 1f;
        [Tooltip("Unit health"), SerializeField, Range(1f, 100f)] private float _unitHealth = 50f;
        [Tooltip("Unit fast attack damage"), SerializeField, Range(1f, 50)] private float _fastDamage = 10f;
        [Tooltip("Unit strong attack damage"), SerializeField, Range(1f, 75f)] private float _strongDamage = 15f;
        [Tooltip("Unit miss probability"), SerializeField, Range(1f, 75f)] private float _missPtobability = 1;
        [Tooltip("Unit critical attack"), SerializeField, Range(1f, 75f)] private float _criticalAttack = 1;

        [Header("Parameters Upgrade Change")]
        [Tooltip("Unit attack increase with upgrade"), SerializeField, Range(1f, 15f)] private float _attackIncrease = 5;
        [Tooltip("Unit health increase with upgrade"), SerializeField, Range(1f, 25f)] private float _healthIncrease = 10;
        [Tooltip("Unit speed increase with upgrade"), SerializeField, Range(0.005f, 0.04f)] private float _speedIncrease = 0.01f;
        [Tooltip("Unit miss probability increase with upgrade"), SerializeField, Range(0.5f, 5f)] private float _missIncrease = 1;
        [Tooltip("Unit critical attack increase with upgrade"), SerializeField, Range(0.5f, 5f)] private float _criticalIncrease = 1;

        private int _killsStatisticRed;
        private int _killsStatisticGreen;
        private int _killsStatisticBlue;


        public float UnitSpeed
        {
            get { return _unitSpeed; }
            set { _unitSpeed = value; }
        }

        public float TargetRange
        {
            get { return _targetRange; }
            set { _targetRange = value; }
        }

        public float FOVRange
        {
            get { return _FOVRange; }
            set { _FOVRange = value; }
        }

        public float AttackRange
        {
            get { return _attackRange; }
            set { _attackRange = value; }
        }

        public float UnitHealth
        {
            get { return _unitHealth; }
            set { _unitHealth = value; }
        }

        public float FastDamage
        {
            get { return _fastDamage; }
            set { _fastDamage = value; }
        }

        public float StrongDamage
        {
            get { return _strongDamage; }
            set { _strongDamage = value; }
        }

        public float MissProbability
        {
            get { return _missPtobability; }
            set { _missPtobability = value; }
        }

        public float CriticalAttack
        {
            get { return _criticalAttack; }
            set { _criticalAttack = value; }
        }

        public float HealthIncrease
        {
            get { return _healthIncrease; }
            set { _healthIncrease = value; }
        }

        public float AttackIncrease
        {
            get { return _attackIncrease; }
            set { _attackIncrease = value; }
        }

        public float SpeedIncrease
        {
            get { return _speedIncrease; }
            set { _speedIncrease = value; }
        }

        public float MissIncrease
        {
            get { return _missIncrease; }
            set { _missIncrease = value; }
        }

        public float CriticalIncrease
        {
            get { return _criticalIncrease; }
            set { _criticalIncrease = value; }
        }


        public int KillsStatisticRed
        {
            get { return _killsStatisticRed; }
            set { _killsStatisticRed = value; }
        }

        public int KillsStatisticGreen
        {
            get { return _killsStatisticGreen; }
            set { _killsStatisticGreen = value; }
        }

        public int KillsStatisticBlue
        {
            get { return _killsStatisticBlue; }
            set { _killsStatisticBlue = value; }
        }
    }
}