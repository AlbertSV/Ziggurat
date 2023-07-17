using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using static UnityEngine.GraphicsBuffer;

namespace Ziggurat
{
    public class TaskAttack : Node
    {
        private Transform _lastTarget;
        private EnemyManager _enemyManager;
        private Dictionary<string, object> _dataContext;
        private Animator _animator;


        public TaskAttack(Transform transform, Dictionary<string, object> dataContext)
        {
            _animator = transform.GetComponent<Animator>();
            _dataContext = dataContext;
        }

        public override NodeState Evaluate()
        { 

            Transform target = (Transform)GetData("target", _dataContext);

            if (target != _lastTarget)
            {
                _enemyManager = target.GetComponent<EnemyManager>();
                _lastTarget = target;
            }

            _enemyManager.TakeHit(_animator);

            if(_enemyManager.IsDead)
            {
                _enemyManager.GotParameters = false;
                ClearData("target", _dataContext);

                _state = NodeState.SUCCESS;

                return _state;
            }

            _state = NodeState.RUNNING;
            return _state;
        }

    }
}