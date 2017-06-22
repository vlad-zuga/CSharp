using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Tree<T>
    {
        int _id = 0;

        public Node<T> root;
        public Tree()
        {
            root = new Node<T>(_id++);
        }

        public Node<T> Add(T data, Node<T> parent)
        {
            Node<T> newNode = new Node<T>(_id++, data);
            parent.Children.Add(newNode);
            return newNode;
        }

        public void Remove(Node<T> node)
        {
            Traverse(null, currNode => currNode.Children.Contains(node), currNode => currNode.Children.Remove(node));
        }

        public Node<T> FindNode(T data)
        {
            Node<T> foundNode = null;

            Traverse(null, node => node.Data.Equals(data), node => foundNode = node);

            return foundNode;
        }

        public IEnumerable<Node<T>> SearchNodes(T data)
        {
            List<Node<T>> list = new List<Node<T>>();

            Traverse(node => list.Add(node), null, null, node => node.Data.Equals(data));

            return list;
        }

        public IEnumerable<Node<T>> TraverseBreadthFirst()
        {
            List<Node<T>> traversal = new List<Node<T>>();

            Traverse(node => traversal.Add(node));          

            return traversal;
        }

        private void PrintNode(Node<T> node)
        {
            Console.WriteLine(node.Data);
        }

        public void PrintAll()
        {
            Traverse(PrintNode);
        }

        private IEnumerable<Node<T>> Traverse(Action<Node<T>> action, Func<Node<T>, bool> stopCondition = null, Action<Node<T>> stopAction = null, Func<Node<T>, bool> actionCondition = null)
        {
            Queue<Node<T>> q = new Queue<Node<T>>();

            List<Node<T>> traversal = new List<Node<T>>();

            q.Enqueue(root);

            while (q.Count() != 0)
            {
                var currNode = q.Dequeue();

                if (action != null)
                {
                    if (actionCondition == null || actionCondition(currNode))
                    {
                        action(currNode);
                    }
                }

                if (stopCondition == null || !stopCondition(currNode))
                {
                    foreach (Node<T> node in currNode.Children)
                    {
                        q.Enqueue(node);
                    }
                }
                else
                {
                    if(stopAction != null)
                    {
                        stopAction(currNode);
                    }
                }
            }

            return traversal;
        }
    }
}
