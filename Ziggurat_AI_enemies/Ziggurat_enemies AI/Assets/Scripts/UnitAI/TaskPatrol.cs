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

        private float _waitTime = 1f;
        private float _waitCounter = 0f;
        private bool _waiting = false;
        private bool _isFirstPoint = true;
        private Vector3 _pointToPatrol = new Vector3();
        private Vector3 _newPoint = new Vector3();
        private bool _isRunning;

        public TaskPatrol(Transform transform, bool isRunning)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
            _isRunning = isRunning;
        }

        public override NodeState Evaluate()
        {
            if (_waiting)
            {
                _waitCounter += Time.deltaTime;
                if(_waitCounter >= _waitTime)
                {
                    _waiting = false;
                    _animator.SetFloat("Movement", 1f);
                }
            }
            else
            {
                if(Vector3.Distance(_transform.position, _pointToPatrol) < 0.01f)
                {
                    Debug.Log("1");
                    _transform.position = _pointToPatrol;
                    _waitCounter = 0f;
                    _waiting = true;
                    _animator.SetFloat("Movement", 0f);
                    _pointToPatrol = ChosePoint();
                }
                else
                {
                    Debug.Log("2");
                    ChosePoint();
                    _animator.SetFloat("Movement", 1f);
                    _transform.position = Vector3.MoveTowards(_transform.position, _pointToPatrol, GameManager.Manager._unitSpeed);
                    _transform.LookAt(_pointToPatrol);
                }
            }

            _state = NodeState.RUNNING;
            return _state;
        }

        private Vector3 RandomPoint()
        {
            float x = Random.Range(-35f, 34f);
            float y = _transform.position.y;
            float z = Random.Range(-34f, 35f);

            return new Vector3(x, y, z);
        }

        private Vector3 ChosePoint()
        {
            Debug.Log(_isFirstPoint);
            if (_isFirstPoint == true)
            {
                _isFirstPoint = false;
                _isRunning = true;
                Debug.Log("3");
                _pointToPatrol = new Vector3(0f,_transform.position.y, 0f);
            }
            else
            {
                if (Vector3.Distance(_transform.position, _pointToPatrol) < 0.01f)
                {
                    Debug.Log("4");
                    _isRunning = false;
                }

                if (_isRunning)
                {
                    Debug.Log("5");
                    return _pointToPatrol;
                }

                else
                {
                    Debug.Log("6");
                    _pointToPatrol = RandomPoint();
                    _isRunning = true;
                }
            }

            return _pointToPatrol;
        }

    }
}