using System;
using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;

namespace Ziggurat
{
    public class UnitBT : BehaviourTree.Tree
    {

        protected override Node SetupTree()
        {

            Node _root = new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new CheckEnemyInAttackRange(transform),
                    new TaskAttack(transform),
                }),
                new Sequence(new List<Node>
                {
                    new CheckEnemyInRange(transform),
                    new TaskGoToTarget(transform),
                }),
                new TaskPatrol(this.transform, GameManager.Manager._onePoint),
            });
            return _root;
        }
    }
}
