using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class Tree : MonoBehaviour
    {
        private Node _root = null;

        private void Update()
        {
            _root = SetupTree();

            if (_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}