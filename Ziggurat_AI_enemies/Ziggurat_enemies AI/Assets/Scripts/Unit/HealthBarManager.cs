using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ziggurat
{
    public class HealthBarManager : MonoBehaviour
    {
        [SerializeField] Image _healthBarSprite;

        private float _maxHealth;
        private float _currentHealth;
        private Camera _camera;

        void Start()
        {
            _camera = Camera.main;
            _maxHealth = gameObject.GetComponentInParent<UnitControl>().MaxHealth;
            _currentHealth = gameObject.GetComponentInParent<UnitControl>().Health;
            HealthBarUpdate(_currentHealth, _maxHealth);
        }

        void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
            _currentHealth = gameObject.GetComponentInParent<UnitControl>().Health;
            HealthBarUpdate(_currentHealth, _maxHealth);
        }

        private void HealthBarUpdate(float currentHealth, float maxHealth)
        {
            _healthBarSprite.fillAmount = currentHealth / maxHealth;
        }
    }
}