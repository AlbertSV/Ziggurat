using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ziggurat
{
    public class UnitControl : MonoBehaviour
    {
        private GameObject _unitOpenButton;
        private GameObject _unitPanelColor;
        private TeamColor teamColorUnit;
        private bool _isFirstPoint = true;
        private Vector3 _pointToPatrol = new Vector3();
        private bool _isRunning;
        private float _health;
        private float _previousHealth;
        private Animator _animator;
        private float _attackCounter = 2f;
        private GameManager _gameManager;
        private Dropdown _dropdowns;
        private float _maxHealth;


        private Dictionary<string, int> _chances = new Dictionary<string, int>()
        {
            {"FastAttackChance", 20},
            {"StrongAttackChance", 5},
            {"BlockChance", 0}
        };

        public float AttackCounter
        {
            get { return _attackCounter; }
            set { _attackCounter = value; }
        }

        public GameObject UnitOpenButton
        {
            get { return _unitOpenButton; }
            set { _unitOpenButton = value; }
        }

        public float Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public Dictionary<string, int> Chances
        {
            get { return _chances; }
            set { _chances = value; }
        }

        public float MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        private void Start()
        {
            GetTeamParameters();
            if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
            }

            if (gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Red)
            {
                gameObject.GetComponent<RedTeamParameters>().SetParameters();
                MaxHealth = gameObject.GetComponent<RedTeamParameters>().RedParameters["Health"];
                Health = gameObject.GetComponent<RedTeamParameters>().RedParameters["Health"];
            }
            else if (gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Blue)
            {
                gameObject.GetComponent<BlueTeamParameters>().SetParameters();
                MaxHealth = gameObject.GetComponent<BlueTeamParameters>().BlueParameters["Health"];
                Health = gameObject.GetComponent<BlueTeamParameters>().BlueParameters["Health"];
            }
            else
            {
                gameObject.GetComponent<GreenTeamParameters>().SetParameters();
                MaxHealth = gameObject.GetComponent<GreenTeamParameters>().GreenParameters["Health"];
                Health = gameObject.GetComponent<GreenTeamParameters>().GreenParameters["Health"];
            }

            UnitOpenButton = _gameManager._unitButton;
            _previousHealth = Health;
        }


        public void PanelButtonControl(GameObject hitted)
        {
            if (hitted != null)
            {
                UnitOpenButton.SetActive(true);
            }
        }

        public GameObject SetPanelColor()
        {
            teamColorUnit = gameObject.GetComponent<GetColor>().GetTeamColor;

            if (teamColorUnit == TeamColor.Red)
            {
                _unitPanelColor = _gameManager._redUnitPanel;
            }
            else if (teamColorUnit == TeamColor.Blue)
            {
                _unitPanelColor = _gameManager._blueUnitPanel;
            }
            else
            {
                _unitPanelColor = _gameManager._greenUnitPanel;
            }

            return _unitPanelColor;
        }

        private Vector3 RandomPoint()
        {
            float x = Random.Range(-35f, 34f);
            float y = 2.04f;
            float z = Random.Range(-34f, 35f);

            return new Vector3(x, y, z);
        }

        public Vector3 ChosePoint()
        {
            if (_isFirstPoint == true)
            {
                _pointToPatrol = new Vector3(0f, 2.04f, 0f);
                _isFirstPoint = false;
                _isRunning = true;
            }
            else
            {
                if (Vector3.Distance(transform.position, _pointToPatrol) < 0.01f)
                {
                    _isRunning = false;
                }

                if (_isRunning)
                {
                    return _pointToPatrol;
                }

                else
                {
                    _pointToPatrol = RandomPoint();
                    _isRunning = true;
                }
            }

            return _pointToPatrol;
        }

        public void GetTeamParameters()
        {
            if (gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Red)
            {
                gameObject.AddComponent<RedTeamParameters>();

            }
            else if (gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Blue)
            {
                gameObject.AddComponent<BlueTeamParameters>();
            }
            else
            {
                gameObject.AddComponent<GreenTeamParameters>();
            }
        }

        //public void HealthImpactControl()
        //{
        //    if(_animator == null)
        //    {
        //        _animator = gameObject.GetComponent<Animator>();
        //    }

        //    //if(Health != _previousHealth)
        //    //{
        //    //    _previousHealth = Health;
        //    //    //In case if there is Impact from attack
        //    //    //_animator.SetTrigger("Impact");
        //    //    AttackCounter = 0f;
        //    //}
        //}

    }
}