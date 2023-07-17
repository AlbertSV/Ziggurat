using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

namespace Ziggurat
{
    public class TaskGoToTarget : Node
    {
        private Transform _transform;
        private Dictionary<string, object> _dataContext;
        private bool _isRunningToPoint;
        private GameManager _gameManager;

        public TaskGoToTarget(Transform transform, Dictionary<string, object> dataContext,bool isRunning)
        {
            _transform = transform;
            _dataContext = dataContext;
            _isRunningToPoint = isRunning;
        }

        public override NodeState Evaluate()
        {
            Transform target = (Transform)GetData("target", _dataContext);

            if (_gameManager == null)
            {
                _gameManager = GameObject.FindObjectOfType<GameManager>();
            }


            if (target == null)
            {
                ClearData("target", _dataContext);
                _state = NodeState.FAILURE;
                _isRunningToPoint = false;
                return _state;
            }

            if (target != null)
            {
                if (Vector3.Distance(_transform.position, target.position) > 0.01f && Vector3.Distance(_transform.position, target.position) <= 2f)
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, target.position, _gameManager.UnitSpeed);
                    _transform.LookAt(target.position);
                }
                else
                {
                    ClearData("target", _dataContext);
                    _state = NodeState.FAILURE;
                    _isRunningToPoint = false;
                    return _state;
                }
            }
            _state = NodeState.RUNNING;
            return _state;
        }
    }
}