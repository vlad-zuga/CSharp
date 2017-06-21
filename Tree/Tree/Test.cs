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

            Node<int> n = t.Add(20, t.root);
            t.Add(30, n);
            n = t.Add(15, n);
            t.Add(22, t.root);
            t.Add(17, n);
            t.Remove(n);

            var traversal = t.TraverseBreadthFirst();
            foreach(var item in traversal)
            {
                Console.WriteLine("({0}, {1})", item.Id, item.Data);
            }
            Console.Read();
        }
    }
}
