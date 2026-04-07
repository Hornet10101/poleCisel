namespace Morseovka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Insert("", "start");
            tree.Insert(".", "E");
            tree.Insert("-", "T");
            tree.Insert(".", "I");
            tree.Insert("-", "A");
            tree.Insert(".", "N");
            tree.Insert("-", "M");
            tree.Insert(".", "S");
            tree.Insert("-", "U");
            tree.Insert(".", "R");
            tree.Insert("-", "W");
            tree.Insert(".", "D");
            tree.Insert("-", "K");
            tree.Insert(".", "G");
            tree.Insert("-", "O");
            tree.Insert(".", "H");
            tree.Insert("-", "V");
            tree.Insert(".", "F");
            tree.Insert("-", "invalid");
            tree.Insert(".", "L");
            tree.Insert("-", "invalid");
            tree.Insert(".", "P");
            tree.Insert("-", "J");
            tree.Insert(".", "B");
            tree.Insert("-", "X");
            tree.Insert(".", "C");
            tree.Insert("-", "Y");
            tree.Insert(".", "Z");
            tree.Insert("-", "Q");
            string test = tree.Find(".---");
            Console.WriteLine(test);
        }
    }
    class Node<T> //T muze byt libovolny typ
    {
        public string Key;
        public T Value;

        public Node<T> LeftSon;
        public Node<T> RightSon;
        public Node(string key, T value) //konstruktor
        {
            Key = key;
            Value = value;
        }
    }
    class BinarySearchTree<T>
    {
        public Node<T> Root;

        public void Insert(string newKey, T newValue)
        {
            void _insert(Node<T> node, string newKey, T newValue) //privatni funkce
            {
                //zaplnujeme zleva
                if (node.LeftSon == null)
                {
                    node.LeftSon = new Node<T>(newKey, newValue);
                }
                else if (node.RightSon == null)
                {
                    node.RightSon = new Node<T>(newKey, newValue);
                }
                else if (node.LeftSon.LeftSon == null || node.LeftSon.RightSon == null)
                {
                    _insert(node.LeftSon, newKey, newValue);
                }
                else
                {
                    _insert(node.RightSon, newKey, newValue);
                }
            }


            if (Root == null)
                Root = new Node<T>(newKey, newValue);
            else
                _insert(Root, newKey, newValue);
        }

        public string Find(string combination)
        {
            int i = 0;
            char dot = '.';
            char dash = '-';
            Node<T> node = Root;
            while (i < combination.Length)
            {
                if (combination[i] == dot)
                {
                        
                    node = node.LeftSon;
                }
                else if(combination[i] == dash)
                {
                    node = node.RightSon;
                }
                i++;
            }
            return node.Value.ToString();
            
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
                        Console.Write(node.Value);
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
    }
}
