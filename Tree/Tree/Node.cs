using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node<T>
    {
        public Node<T> parent;
        public int Id;
        public List<Node<T>> Children;
        public T Data;

        public Node(int pId, T pData = default(T))
        {
            Id = pId;
            Data = pData;
            Children = new List<Node<T>>();
        }

        public Node<T> Copy()
        {
            return new Node<T>(Id, Data);
        }
    }
}
