using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class EnemyManager : MonoBehaviour
    {
        private float _unitHealthPoints;
        private bool isSpawned = false;
        private Animator _animator;
        private bool _isDead = false;

        private float _fastAttackTime = 1f;
        private float _attackCounter = 2f;

        public bool IsDead
        {
            get{ return _isDead; }
            set { _isDead = value; }
        }
         

        public bool TakeHit()
        {
            if (_animator ==null)
            {
                _animator = gameObject.GetComponent<Animator>();
            }

            if (isSpawned == false)
            {
                GetHealth();
                isSpawned = true;
            }

            _attackCounter += Time.deltaTime;
            IsDead = _unitHealthPoints <= 0;

            if(IsDead)
            {
                _Die();
            }

            if (_attackCounter >= _fastAttackTime)
            {
                if (IsDead)
                {
                    _Die();
                }
                else
                {
                    _animator.SetTrigger("Fast");
                }
            }

            return IsDead;
        }

        private void _Die()
        {
            _animator.SetFloat("Movement", 0f);
            _animator.SetTrigger("Die");
        }

        private void GetHealth()
        {
            _unitHealthPoints = GameManager.Manager._unitHealth;
        }

        private void AnimationEventEnd_UnityEditor()
        {
            Destroy(gameObject);
        }

        private void AnimationEventAttackEnd()
        {
            _unitHealthPoints -= GameManager.Manager._fastDamage;
            _attackCounter = 0f;
        }
    }
}