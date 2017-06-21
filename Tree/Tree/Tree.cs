using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Tree<T>
    {
        public Node<T> root;
        public Tree()
        {
            root = new Node<T>(0);
        }

        public void Add(Node<T> node, Node<T> parent)
        {
            parent.Children.Add(node);
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
    }
}
