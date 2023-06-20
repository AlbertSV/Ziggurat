using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

namespace Ziggurat
{
    public class CheckEnemyInRange : Node
    {
        private Transform _transform;
        private List<GameObject> _enemyList = new List<GameObject>();
        private Animator _animator;

        public CheckEnemyInRange(Transform transform)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
        }

        public override NodeState Evaluate()
        {
            object target = GetData("target");
            Debug.Log(target);
            if(target == null)
            {
                Collider[] colliders = Physics.OverlapSphere(_transform.position, GameManager.Manager._FOVRange);


                if(colliders.Length > 0)
                {
                    foreach(Collider collider in colliders)
                    {
                        if(collider.gameObject.GetComponent<Unit>() != null &&
                            collider.gameObject.GetComponent<GetColor>().GetTeamColor != _transform.gameObject.GetComponent<GetColor>().GetTeamColor)
                        {
                            _enemyList.Add(collider.gameObject);
                        }
                    }

                    if(_enemyList.Count != 0)
                    {
                        _animator.SetFloat("Movement", 1f);
                        _parent._parent.SetData("target", _enemyList[0].transform);

                        _state = NodeState.SUCCESS;
                        return _state;
                    }

                }

                _state = NodeState.FAILURE;
                return _state;
            }

            _state = NodeState.SUCCESS;
            return _state;
        }

        

    }
}