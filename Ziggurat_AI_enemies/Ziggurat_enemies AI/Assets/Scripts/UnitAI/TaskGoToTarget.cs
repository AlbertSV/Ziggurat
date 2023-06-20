using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

namespace Ziggurat
{
    public class TaskGoToTarget : Node
    {
        private Transform _transform;

        public TaskGoToTarget(Transform transform)
        {
            _transform = transform;
        }

        public override NodeState Evaluate()
        {
            Transform target = (Transform)GetData("target");

            if(Vector3.Distance(_transform.position, target.position) > 0.01f)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, target.position, GameManager.Manager._unitSpeed);
                _transform.LookAt(target.position);
                Debug.Log(_state);
            }

            _state = NodeState.RUNNING;
            return _state;
        }
    }
}