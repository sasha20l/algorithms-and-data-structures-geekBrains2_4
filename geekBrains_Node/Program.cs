using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekBrains_Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node = Insert(new Node<int>(), 100);
            //print(node);
            Console.ReadLine();
        }

        static Node<int> GetFreeNode(int value, Node<int> head)
        {
            Node<int> node = new Node<int>();
            node.Data = value;
            node.Parent = head;
            return node;



        }


        public static Node<int> Insert(Node<int> head, int value)
        {
            Node<int> tmp = null;
            if (head == null)
            {
                head = GetFreeNode(value, null);
                return head;
            }

            tmp = head;
            while (tmp != null)
            {
                if (value > tmp.Data)
                {
                    if (tmp.Right != null)
                    {
                        tmp = tmp.Right;
                        continue;
                    }
                    else
                    {
                        tmp.Right = GetFreeNode(value, tmp); ;
                        return head;
                    }
                }
                else if (value < tmp.Data)
                {
                    if (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                        continue;
                    }
                    else
                    {
                        tmp.Left = GetFreeNode(value, tmp);
                        return head;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");                  // Дерево построено неправильно
                }
            }
            return tmp;
        }
        private static Node<int> Search(Node<int> node, int value)
        {
            if (node == null) return null;
            switch (value.CompareTo(node.Data))
            {
                case 1: return Search(node.Right, value);
                case -1: return Search(node.Left, value);
                case 0: return node;
                default: return null;
            }
        }
        private static void _print(Node<int> node)
        {
            if (node == null) return;
            _print(node.Left);
            node.listForPrint.Add(node.Data);
            Console.Write(node + " ");
            if (node.Right != null)
                _print(node.Right);
        }
        public static void print(Node<int> node)
        {
            node.listForPrint.Clear();
            _print(node);
            Console.WriteLine();
        }

    }
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }

        public List<T> listForPrint = new List<T>();
    }
}
