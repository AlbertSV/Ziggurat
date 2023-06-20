using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

namespace Ziggurat
{
    public class TaskAttack : Node
    {
        private Transform _lastTarget;
        private EnemyManager _enemyManager;

        private Animator _animator;

        private float _fastAttackTime = 1f;
        private float _attackCounter = 0f;

        public TaskAttack(Transform transform)
        {
            _animator = transform.GetComponent<Animator>();
        }

        public override NodeState Evaluate()
        {
            Transform target = (Transform)GetData("target");
            Debug.Log(GetData("target"));

            if (target != _lastTarget)
            {
                _enemyManager = target.GetComponent<EnemyManager>();
                _lastTarget = target;
            }
            _attackCounter += Time.deltaTime;
            if(_attackCounter >= _fastAttackTime)
            {
                bool isEnemyDead = _enemyManager.TakeHit();
                if(isEnemyDead)
                {
                    ClearData("target");
                    _animator.SetTrigger("Fast");
                    _animator.SetFloat("Movement", 1f);
                }
                else
                {
                    _attackCounter = 0f;
                }

                
            }

            _state = NodeState.RUNNING;
            return _state;
        }
    }
}