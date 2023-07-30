using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ziggurat
{
    public class HealthBarManager : MonoBehaviour
    {
        [SerializeField] private Image _healthBarSprite;
        [SerializeField] private GameObject _healthBar;

        private float _maxHealth;
        private float _currentHealth;
        private Camera _camera;
        private PlayerPanel _playerPanel;
        

        void Start()
        {
            _camera = Camera.main;
            _maxHealth = gameObject.GetComponent<UnitControl>().MaxHealth;
            _currentHealth = gameObject.GetComponent<UnitControl>().Health;
            HealthBarUpdate(_currentHealth, _maxHealth);
            _playerPanel = FindObjectOfType<PlayerPanel>();
        }

        void Update()
        {
            _healthBar.transform.rotation = Quaternion.LookRotation(_healthBar.transform.position - _camera.transform.position);
            _currentHealth = gameObject.GetComponent<UnitControl>().Health;
            HealthBarUpdate(_currentHealth, _maxHealth);
            SwitchHealthBar();
        }

        private void HealthBarUpdate(float currentHealth, float maxHealth)
        {
            _healthBarSprite.fillAmount = currentHealth / maxHealth;
        }

        public void SwitchHealthBar()
        {
            if (_playerPanel.HealthBarToggle.isOn)
            {
                _healthBar.SetActive(true);
            }
            else
            {
                _healthBar.SetActive(false);
            }
        }
    }
}