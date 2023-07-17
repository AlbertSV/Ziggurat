using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

namespace Ziggurat
{
    public class CheckEnemyInAttackRange : Node
    {
        private Transform _transform;
        private Animator _animator;
        private Dictionary<string, object> _dataContext;
        private EnemyManager _enemyManager;
        private GameManager _gameManager;

        public CheckEnemyInAttackRange(Transform transform, Dictionary<string, object> dataContext)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
            _dataContext = dataContext;
        }

        public override NodeState Evaluate()
        {
            if (_gameManager == null)
            {
                _gameManager = GameObject.FindObjectOfType<GameManager>();
            }

            if (_enemyManager == null)
            {
                _enemyManager = _transform.gameObject.GetComponent<EnemyManager>();
            }

            Transform target = (Transform)GetData("target", _dataContext);
            if (target == null)
            {
                _state = NodeState.FAILURE;
                return _state;
            }

            Transform targetTransform = (Transform)target;

            if(Vector3.Distance(_transform.position, targetTransform.position) <= _gameManager.AttackRange)
            {
                _animator.SetFloat("Movement", 0f);

                _state = NodeState.SUCCESS;
                return _state;
            }

            _state = NodeState.FAILURE;
            return _state;
        }
    }
}