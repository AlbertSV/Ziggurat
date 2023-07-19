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
        }


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

        public void PanelButtonControl(GameObject hitted)
        {
            if (hitted != null)
            {
                ZigguratOpenButton.SetActive(true);
            }
        }

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
    }
}