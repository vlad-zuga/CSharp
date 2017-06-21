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

        public void Remove(Node<T> node) //doesn't treat node == root case
        {
            Queue<Node<T>> q = new Queue<Node<T>>();
            q.Enqueue(root);

            while (q.Count() != 0)
            {
                var currNode = q.Dequeue();

                if (currNode.Children.Contains(node))
                {
                    currNode.Children.Remove(node);
                }
                else
                {
                    foreach (Node<T> n in currNode.Children)
                    {
                        q.Enqueue(n);
                    }
                }
            }
        }

        public Node<T> FindNode(T data)
        {
            Queue<Node<T>> q = new Queue<Node<T>>();
            q.Enqueue(root);

            while (q.Count() != 0)
            {
                var currNode = q.Dequeue();

                if (currNode.Data.Equals(data))
                {
                    return currNode;
                }
                else
                {
                    foreach (Node<T> node in currNode.Children)
                    {
                        q.Enqueue(node);
                    }
                }
            }

            return null;
        }
        public IEnumerable<Node<T>> TraverseBreadthFirst()
        {
            Queue<Node<T>> q = new Queue<Node<T>>();
            List<Node<T>> traversal = new List<Node<T>>();
            q.Enqueue(root);

            while (q.Count() != 0)
            {
                var currNode = q.Dequeue();

                traversal.Add(currNode);

                foreach (Node<T> n in currNode.Children)
                {
                    q.Enqueue(n);
                }
            }

            return traversal;
        }

        private IEnumerable<Node<T>> Traverse(Action<Node<T>> action, Func<Node<T>, bool> stopCondition)
        {
            Queue<Node<T>> q = new Queue<Node<T>>();

            List<Node<T>> traversal = new List<Node<T>>();

            q.Enqueue(root);

            while (q.Count() != 0)
            {
                var currNode = q.Dequeue();

                action(currNode);

                if (!stopCondition(currNode))
                {
                    foreach (Node<T> node in currNode.Children)
                    {
                        q.Enqueue(node);
                    }
                }
            }

            return traversal;
        }
    }
}
