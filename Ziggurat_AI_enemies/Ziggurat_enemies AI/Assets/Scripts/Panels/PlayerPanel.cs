using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ziggurat
{
    public class PlayerPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPanel;
        [SerializeField] Toggle _healthBarToggle;

        private Animator _animator;
        private bool _isActive = false;
        private bool _barIsActive = true;
        private List<GameObject> _allHealthBars = new List<GameObject>();
        

        public bool BarIsActive
        {
            get { return _barIsActive; }
            set { _barIsActive = value; }
        }

        public Toggle HealthBarToggle
        {
            get { return _healthBarToggle; }
            set { _healthBarToggle = value; }
        }

        private void Start()
        {
            _animator = _playerPanel.GetComponent<Animator>();
        }

        public void PlayerPanelActivate()
        {
            if(_playerPanel != null && _isActive == false)
            {
                _playerPanel.SetActive(true);
                _animator.SetBool("Open", true);
                _isActive = true;
               
            }
            else if(_playerPanel != null && _isActive == true)
            {
                _animator.SetBool("Open", false);
                StartCoroutine(WaitForAnimation());
                _isActive = false;
            }
        }

        private IEnumerator WaitForAnimation()
        {
            yield return new WaitForSeconds(1f);
            _playerPanel.SetActive(false);
        }

        public void DestroyAllUnits()
        {
            GameObject[] _allUnits = GameObject.FindGameObjectsWithTag("Unit");
            foreach(GameObject unit in _allUnits)
            {
                Destroy(unit);
            }
        }
    }
}