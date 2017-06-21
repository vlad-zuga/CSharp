using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Test
    {
        public static void Main()
        {
            Tree<int> t = new Tree<int>();

            Node<int> n = new Node<int>(1, 20);
            t.Add(n, t.root);
            Node<int> tmp = t.FindNode(20);
            n = new Node<int>(2, 30);
            t.Add(n, tmp);
            Node<int> n2 = n;
            n.Data = 15;
            n.Id = 3;
            t.Add(n, tmp);
            t.Remove(n2);
            
            foreach(Node<int> node in tmp.Children)
            {
                Console.WriteLine("{0}", node.Data);
            }
            Console.Read();
        }
    }
}
