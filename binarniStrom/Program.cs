using System.Xml.Linq;
using System.Xml.Schema;

namespace binarniStrom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Insert(4, "a");
            tree.Insert(6, "b");
            tree.Insert(10, "c");
            tree.Insert(1, "d");
            tree.Insert(3, "e");
            tree.Insert(7, "f");
            tree.Insert(15, "g");
            tree.Insert(8, "h");
            tree.Insert(5, "i");

            tree.PrintTree();
        }
    }
    class Node<T> //T muze byt libovolny typ
    {
        public int Key;
        public T Value;

        public Node<T> LeftSon;
        public Node<T> RightSon;
        public Node(int key, T value) //konstruktor
            {
            Key = key;
            Value = value;
            }
    }
    class BinarySearchTree<T>
    {
        public Node<T> Root;

        public void Insert(int newKey, T newValue)
        {
            void _insert(Node<T> node, int newKey, T newValue) //privatni funkce
            {

                if (newKey < node.Key) //jdeme doleva
                { 
                    if (node.LeftSon == null)
                    {
                        node.LeftSon = new Node<T>(newKey, newValue);
                    }
                    else 
                    {
                        _insert(node.LeftSon, newKey, newValue);
                    }
                }
                else if (newKey > node.Key)
                {
                    if (node.RightSon == null)
                    {
                        node.RightSon = new Node<T>(newKey, newValue);
                    }
                    else
                    {
                        _insert(node.RightSon, newKey, newValue);
                    }
                }
                else //stejnej klic, nema se stat
                {
                    throw new Exception();
                }
            }


            if (Root == null)
                Root = new Node<T>(newKey, newValue);
            else
                _insert(Root, newKey, newValue);
        }

        public Node<T> Find(int targetKey)
        {
            if (Root == null)
                return null;
            
            Node<T> _find(Node<T> node, int targetKey)
            {
                if (node.Key == targetKey)
                    return node;
                else if(targetKey < node.Key)
                    return _find(node.LeftSon, targetKey);
                else
                    return _find(node.RightSon, targetKey);
                
            }

            Node<T> targetNode = _find(Root, targetKey);
            return targetNode;
        }
        public Node<T> FindMinimum(Node<T> node = null)
        {
            if (Root == null)
                return null;

            Node<T> _findMin(Node<T> node)
            {
                if (node.LeftSon == null)
                    return node;
                else
                    return _findMin(node.LeftSon);
            }
            if (node == null)
            {
                return _findMin(Root);
            }
            else
            {
                return _findMin(node);
            }
        }
        public void PrintTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Strom neexistuje");
            }
            else
            {
                Queue<Node<T>> queue = new Queue<Node<T>>();
                string dashes = "";
                queue.Enqueue(Root);
                queue.Enqueue(null);
                while (queue.Count > 0)
                {
                    Node<T> node = queue.Dequeue();
                    if (node == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine(dashes);
                        dashes = "";
                        if (queue.Count > 0)
                        {
                            queue.Enqueue(null);
                        }
                    }
                    else
                    {
                        Console.Write(node.Key);
                        Console.Write(" ");
                        if (node.LeftSon != null)
                        {
                            queue.Enqueue(node.LeftSon);
                            dashes = dashes + "/ ";
                        }
                        if (node.RightSon != null)
                        {
                            queue.Enqueue(node.RightSon);
                            dashes = dashes + "\\ ";
                        }
                    }
                }

            }
        }
        public void Remove(int targetKey)
        {
            Node<T> toRemove = Find(targetKey);
            if (toRemove.RightSon == null && toRemove.LeftSon == null)
            {
                toRemove = null;
            }
            else if (toRemove.RightSon == null && toRemove.LeftSon != null) 
            {
                toRemove = toRemove.LeftSon;
            }
            else if (toRemove.RightSon != null && toRemove.LeftSon == null)
            {
                toRemove = toRemove.RightSon;
            }
            else
            {
                Node<T> newNode = FindMinimum(toRemove.RightSon);
                toRemove = newNode;
                Remove(newNode.Key);
            }

        }
    }
}
