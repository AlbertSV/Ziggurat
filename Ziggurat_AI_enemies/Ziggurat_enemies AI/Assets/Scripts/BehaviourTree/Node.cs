using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class Node
    {
        protected NodeState _state;

        public Node _parent;
        protected List<Node> _children = new List<Node>();

        public Node()
        {
            _parent = null;
        }

        public Node(List<Node> children)
        {
            foreach (Node child in children)
            {
                Attach(child);
            }
        }

        private void Attach(Node node)
        {
            node._parent = this;
            _children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;

        public void SetData(string key, object value, Dictionary<string, object> dataContext)
        {
            dataContext[key] = value;
        }

        public object GetData(string key,  Dictionary<string, object> dataContext)
        {
            object value = null;
            if (dataContext.TryGetValue(key, out value))
            {
                return value;
            }

            Node node = _parent;
            while (node != null)
            {
                value = node.GetData(key,  dataContext);
                if (value != null)
                {
                    return value;
                }
                node = node._parent;
            }
            return null;
        }

        public bool ClearData(string key, Dictionary<string, object> dataContext)
        {
            if (dataContext.ContainsKey(key))
            {
                dataContext.Remove(key);
                return true;
            }

            Node node = _parent;
            if (node != null)
            {
                bool cleared = node.ClearData(key, dataContext);
                if (cleared)
                    return true;
                node = node._parent;

            }
            return false;
        }
    }
}