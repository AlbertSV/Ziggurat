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
        private Dictionary<string, object> _dataContext;
        private Animator _animator;
        private bool _isRunningToPoint;

        public TaskAttack(Transform transform, Dictionary<string, object> dataContext, bool isRunning)
        {
            _animator = transform.GetComponent<Animator>();
            _dataContext = dataContext;
            _isRunningToPoint = isRunning;
        }

        public override NodeState Evaluate()
        {
            Debug.Log("attack" + _state);
            Transform target = (Transform)GetData("target", _dataContext);

            if (target != _lastTarget)
            {
                _enemyManager = target.GetComponent<EnemyManager>();
                _lastTarget = target;
            }

            _enemyManager.TakeHit();

            if(_enemyManager.IsDead)
            {
                ClearData("target", _dataContext);

                _state = NodeState.SUCCESS;

                _isRunningToPoint = false;
                return _state;
            }

            _state = NodeState.RUNNING;
            return _state;
        }
    }
}