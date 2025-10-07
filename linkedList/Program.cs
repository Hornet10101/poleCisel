namespace linkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LinkedList spojak = new LinkedList();
            spojak.AddToEnd(3);
            spojak.AddToEnd(4);
            spojak.AddToEnd(8);
            spojak.AddToEnd(6);
            spojak.Print();
            spojak.Max();
            spojak.RemoveLast();
            spojak.Print();
            bool search = spojak.Search(3);
            Console.WriteLine(search);
        }
    }
    class Node
    {
        public Node (int value)
        {
            Value = value;
        }
        public int Value {  get; set; }
        public Node Next { get; set; }
    }
    class LinkedList
    {
        public Node Head { get; set; }
        public void AddToEnd(int value)
        {
            if (Head == null)
            {
                Head = new Node(value);
            }
            else
            {
                Node currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new Node(value);

            }
        }
        public void Print()
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
        public void Max()
        {
            Node currentNode = Head;
            int tempMax = currentNode.Value;
            while (currentNode != null)
            {
                if (tempMax < currentNode.Value)
                {
                    tempMax = currentNode.Value;
                }
                currentNode = currentNode.Next;
            }
            Console.WriteLine($"Max: {tempMax}");
        }
        public void RemoveLast()
        {
            Node currentNode = Head.Next;
            Node previousNode = Head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                previousNode = previousNode.Next;
            }
            previousNode.Next = null;
        }
        public bool Search(int target)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value == target)
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }
    }
}
//TODO: True or False jestli tam prvek je