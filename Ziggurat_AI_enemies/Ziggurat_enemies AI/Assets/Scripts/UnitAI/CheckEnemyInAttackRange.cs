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

        public CheckEnemyInAttackRange(Transform transform)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
        }

        public override NodeState Evaluate()
        {
            object target = GetData("target");
            Debug.Log(target);
            if (target == null)
            {
                _state = NodeState.FAILURE;
                return _state;
            }

            Transform targetTransform = (Transform)target;

            if(Vector3.Distance(_transform.position, targetTransform.position) <= GameManager.Manager._attackRange)
            {
                Debug.Log(GetData("target"));
                _animator.SetFloat("Movement", 0f);
                _animator.SetTrigger("Fast");

                _state = NodeState.SUCCESS;
                return _state;
            }

            _state = NodeState.FAILURE;
            return _state;
        }
    }
}