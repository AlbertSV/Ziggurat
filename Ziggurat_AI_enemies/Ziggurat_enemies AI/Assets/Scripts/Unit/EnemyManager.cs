using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class EnemyManager : MonoBehaviour
    {
        private float _unitHealthPoints;
        private event EventHandler OnEndAnimation;

        private void Awake()
        {
            _unitHealthPoints = GameManager.Manager._unitHealth;
        }

        public bool TakeHit()
        {
            _unitHealthPoints -= GameManager.Manager._fastDamage;

            bool isDead = _unitHealthPoints <= 0;
            if (isDead) _Die();
            return isDead;
        }

        private void _Die()
        {
            Destroy(gameObject);
            OnEndAnimation.Invoke(null, null);
        }
    }
}