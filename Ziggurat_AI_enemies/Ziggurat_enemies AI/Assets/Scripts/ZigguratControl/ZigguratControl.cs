using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ziggurat
{
    public class ZigguratControl : ZigguratPanel
    {
        
        [SerializeField] private Transform unitSpwanPosition;
        [SerializeField] private GameObject _zigguratOpenButton;

        [SerializeField] private TMP_Text _spawnStatText;
        [SerializeField] private TMP_Text _killsStatText;
        [SerializeField] private TMP_Text _timeSpawnText;

        private Material _redMaterial;
        private Material _blueMaterial;
        private Material _greenMaterial;

        private List<GameObject> _redList;
        private List<GameObject> _blueList;
        private List<GameObject> _greenList;
        private GameManager _gameManager;
        private GameObject _unit;
        private GameObject _zigguratPanel;
        private TeamColor teamColor;

        private float _timeSpawn = 5f;
        private float _timeDelay = 10f;
        private bool _stopSpawing = false;
        private bool _firstSpawn = true;
        private float _counter = -1;

        private int _spawnStatistic = 0;

        public GameObject ZigguratOpenButton
        {
            get { return _zigguratOpenButton; }
            set { _zigguratOpenButton = value; }
        }

        public int SpawnStatistic
        {
            get { return _spawnStatistic; }
            set { _spawnStatistic = value; }
        }

        private void Awake()
        {
            _redList = new List<GameObject>();
            _blueList = new List<GameObject>();
            _greenList = new List<GameObject>();

            teamColor = gameObject.GetComponent<GetColor>().GetTeamColor;

            _redMaterial = Resources.Load<Material>("Materials/Red");
            _blueMaterial = Resources.Load<Material>("Materials/Blue");
            _greenMaterial = Resources.Load<Material>("Materials/Green");
            _unit = Resources.Load<GameObject>("RPGHeroPolyart");
        }

        private void Start()
        {
            InvokeRepeating("UnitSpawn", _timeSpawn, _timeDelay);

            if (_gameManager == null)
            {
                _gameManager = GameObject.FindObjectOfType<GameManager>();
            }

        }

        private void Update()
        {
            UpdateStatistic();
            TimeSpawning();
        }

        //Spawn of the unit
        private void UnitSpawn()
        {
            if(teamColor == TeamColor.Red)
            {
                SetUnit(_redMaterial, _unit, _redList, TeamColor.Red);
            }
            else if(teamColor == TeamColor.Blue)
            {
                SetUnit(_blueMaterial, _unit, _blueList, TeamColor.Blue);
            }
            else
            {
                SetUnit(_greenMaterial, _unit, _greenList, TeamColor.Green);
            }

            if(_stopSpawing)
            {
                CancelInvoke();
            }
        }

        //set color of the unit
        private void SetUnit(Material color, GameObject unit, List<GameObject> listColor, TeamColor teamColor)
        {
            unit.GetComponentInChildren<MeshRenderer>().sharedMaterial = color;

            if (unit.GetComponent<GetColor>() == null)
            {
                unit.AddComponent<GetColor>();
            }
            unit.GetComponent<GetColor>().GetTeamColor = teamColor;
               
            var unitSpawn = Instantiate(unit, unitSpwanPosition.position, unitSpwanPosition.rotation, unitSpwanPosition);
            listColor.Add(unitSpawn);
            SpawnStatistic += 1;
        }

        //control of the ziggurat panel
        public void PanelButtonControl(GameObject hitted)
        {
            if (hitted != null)
            {
                ZigguratOpenButton.SetActive(true);
            }
        }

        //set color of the ziggurat and unit panels
        public GameObject SetPanelColor()
        {
            if (teamColor == TeamColor.Red)
            {
                _zigguratPanel = _gameManager._redZigguratPanel;
            }
            else if (teamColor == TeamColor.Blue)
            {
                _zigguratPanel = _gameManager._blueZigguratPanel;
            }
            else
            {
                _zigguratPanel = _gameManager._greenZigguratPanel;
            }

            return _zigguratPanel;
        }

        //statistic of the spawns and kills of the team
        private void UpdateStatistic()
        {
            _spawnStatText.text = "Spawned: " + SpawnStatistic;

            if(gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Red)
            {
                _killsStatText.text = "Killed: " + _gameManager.KillsStatisticRed;
            }
            else if (gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Green)
            {
                _killsStatText.text = "Killed: " + _gameManager.KillsStatisticGreen;
            }
            else
            {
                _killsStatText.text = "Killed: " + _gameManager.KillsStatisticBlue;
            }
        }

        //clear button for statistic
        public void ClearStatistic()
        {
            SpawnStatistic = 0;

            if (gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Red)
            {
                _gameManager.KillsStatisticRed = 0;
            }
            else if (gameObject.GetComponent<GetColor>().GetTeamColor == TeamColor.Green)
            {
                _gameManager.KillsStatisticGreen = 0;
            }
            else
            {
                _gameManager.KillsStatisticBlue = 0;
            }
        }

        //how many seconds left until unit spawn
        private void TimeSpawning()
        {
            
            if (_counter <= 0)
            {
                if (_firstSpawn == true)
                {
                    _counter = _timeSpawn;
                    _firstSpawn = false;
                }
                else
                {
                    _counter = _timeDelay;
                }
            }

            _counter -= Time.deltaTime;

            _timeSpawnText.text = "Spawn in: " + Convert.ToUInt32(_counter);
        }
    }
}