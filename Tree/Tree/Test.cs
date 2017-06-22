using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Test
    {
        static Tree<int> TestAdd(bool first)
        {
            Tree<int> t = new Tree<int>();
            if (first)
            {
                Node<int> n = t.Add(20, t.root);
                t.Add(30, n);
                n = t.Add(15, n);
                t.Add(22, t.root);
                t.Add(17, n);
            }
            else
            {
                Node<int> n = t.Add(20, t.root);
                t.Add(20, n);
                n = t.Add(15, n);
                t.Add(22, t.root);
                t.Add(20, n);
            }

            return t;
        }

        static Tree<int> TestRemove(Tree<int> t, Node<int> n)
        {
            t.Remove(n);
            return t;
        }

        static Node<int> TestFind(Tree<int> t, int dataToFind)
        {
            return t.FindNode(dataToFind);
        }

        static void TestPrint(Tree<int> t)
        {
            var traversal = t.TraverseBreadthFirst();
            Console.WriteLine("Tree Traversal:");
            foreach (var item in traversal)
            {
                Console.WriteLine("({0}, {1})", item.Id, item.Data);
            }
            Console.WriteLine("");
        }

        static void TestPrint(Node<int> n)
        {
            if (n != null)
            {
                Console.WriteLine("Node:");
                Console.WriteLine("({0}, {1})", n.Id, n.Data);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Null node");
                Console.WriteLine("");
            }
        }

        static void TestSearchNodes(Tree<int> t, int data)
        {
            var nodes = t.SearchNodes(20);
            foreach (var item in nodes)
            {
                Console.WriteLine("({0}, {1})", item.Id, item.Data);
            }
            Console.WriteLine("");
        }

        static void TestAddTree(Tree<int> t, Node<int> parent)
        {
            t.Add(t, parent);
        }

        static Node<int> TestFindNode(Tree<int> t, IEnumerable<int> pdataChain)
        {
            return t.FindNode(pdataChain);
        }

        public static void Main()
        {
            Tree<int> t1 = TestAdd(true);
            Node<int> n = TestFind(t1, 15);
            t1 = TestRemove(t1, n);
            TestPrint(t1);

            Tree<int> t2 = TestAdd(false);
            TestPrint(t2);

            n = TestFind(t1, 20);
            TestAddTree(t2, n);
            TestPrint(t1);

            var l1 = new List<int> { 0, 20, 0, 20, 15, 20 };
            var l2 = new List<int> { 0, 20, 30 };
            var l3 = new List<int> { 1, 3, 5 };
            n = TestFindNode(t1, l1);
            TestPrint(n);
            n = TestFindNode(t1, l2);
            TestPrint(n);
            n = TestFindNode(t1, l3);
            TestPrint(n);

            Console.Read();
        }
    }
}
