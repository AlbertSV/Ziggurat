using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

namespace Ziggurat
{
    public class TaskPatrol : Node
    {
        private Transform _transform;
        private Animator _animator;
        private Transform _wayPoints;

        private int _currentWayPointIndex = 0;

        private float _waitTime = 1f;
        private float _waitCounter = 0f;
        private bool _waiting = false;

        public TaskPatrol(Transform transform, Transform wayPoints)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
            _wayPoints = wayPoints;
        }

        public override NodeState Evaluate()
        {
            Debug.Log("asdasda4");
            if (_waiting)
            {
                Debug.Log("asdasda2");
                _waitCounter += Time.deltaTime;
                if(_waitCounter >= _waitTime)
                {
                    Debug.Log("asdasda3");
                    _waiting = false;
                    _animator.SetFloat("Movement", 1f);
                }
            }
            else
            {
                //Transform onePoint = _wayPoints[_currentWayPointIndex];
                if(Vector3.Distance(_transform.position, _wayPoints.position) < 0.01f)
                {
                    Debug.Log("asdasda1");
                    _transform.position = _wayPoints.position;
                    _waitCounter = 0f;
                    _waiting = true;

                   // _currentWayPointIndex = (_currentWayPointIndex + 1) % _wayPoints.Length;
                    _animator.SetFloat("Movement", 0f);
                }
                else
                {
                    _animator.SetFloat("Movement", 1f);
                    _transform.position = Vector3.MoveTowards(_transform.position, _wayPoints.position, GameManager.Manager._unitSpeed);
                    _transform.LookAt(_wayPoints);
                }
            }

            _state = NodeState.RUNNING;
            return _state;
        }
    }
}