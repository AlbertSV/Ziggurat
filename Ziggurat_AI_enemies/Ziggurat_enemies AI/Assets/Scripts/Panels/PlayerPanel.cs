using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class PlayerPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPanel;
        private Animator _animator;
        private bool _isActive = false;

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
    }
}