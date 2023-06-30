using System;
using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ziggurat
{
    public class UnitBT : BehaviourTree.Tree
    {
        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();
        private bool _isRunning = false;

        protected override Node SetupTree()
        {
            Node _root = new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new CheckEnemyInAttackRange(transform, _dataContext),
                    new TaskAttack(transform, _dataContext, _isRunning),
                }),
                new Sequence(new List<Node>
                {
                    new CheckEnemyInRange(transform, _dataContext),
                    new TaskGoToTarget(transform, _dataContext, _isRunning),
                }),
                new TaskPatrol(this.transform, _isRunning),
            });
            return _root;
        }
    }
}
