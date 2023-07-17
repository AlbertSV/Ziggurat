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
        private Vector3 _pointToGo = new Vector3();
        private UnitControl _unitControl;
        private GameManager _gameManager;

        public TaskPatrol(Transform transform, UnitControl unitControl)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
            _unitControl = unitControl;
        }

        public override NodeState Evaluate()
        {
            if(_gameManager == null)
            {
                _gameManager = GameObject.FindObjectOfType<GameManager>();
            }

            if (_waiting)
            {
                _waitCounter += Time.deltaTime;
                if (_waitCounter >= _waitTime)
                {
                    _waiting = false;
                    _animator.SetFloat("Movement", 1f);
                }
            }
            else
            {
                if (Vector3.Distance(_transform.position, _pointToGo) < 0.01f)
                {
                    _transform.position = _pointToGo;
                    _waitCounter = 0f;
                    _waiting = true;
                    _animator.SetFloat("Movement", 0f);
                }
                else
                {
                    _pointToGo = _unitControl.ChosePoint();
                    _animator.SetFloat("Movement", 1f);
                    _transform.position = Vector3.MoveTowards(_transform.position, _pointToGo,  _gameManager.UnitSpeed);
                    _transform.LookAt(_pointToGo);
                }
            }

            _state = NodeState.RUNNING;
            return _state;
        }
    }
}