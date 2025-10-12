namespace LinkedList2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LinkedList spojak = new LinkedList();
            spojak.AddToEnd(3);
            spojak.AddToEnd(3);
            spojak.AddToEnd(4);
            spojak.AddToEnd(8);
            spojak.AddToEnd(6);
            spojak.AddToEnd(3);
            spojak.AddToEnd(6);
            spojak.AddToEnd(9);
            spojak.AddToEnd(0);
            spojak.Print();
            spojak.Max();
            spojak.RemoveLast();
            spojak.Print();
            spojak.RemoveAll(3);
            spojak.Print();
            bool search = spojak.Search(2);
            Console.WriteLine(search);

            LinkedList spojak2 = new LinkedList();
            spojak2.AddToEnd(2);
            spojak2.AddToEnd(3);
            spojak2.AddToEnd(6);
            spojak2.AddToEnd(6);
            spojak2.AddToEnd(1);
            spojak2.AddToEnd(4);
            spojak2.AddToEnd(4);

            LinkedList intersection = Intersection(spojak, spojak2);
            intersection.Print();
            LinkedList union = Union(spojak, spojak2);
            union.AddToEnd(0);
            union.Print();

            Console.WriteLine("");
            Scitani(spojak, spojak2);
        }
            
        public static LinkedList Intersection(LinkedList list1, LinkedList list2)
        {
            Node list1Node = list1.Head;
            LinkedList intersection = new LinkedList();
            while(list1Node != null)
            {
                Node list2Node = list2.Head;
                while (list2Node != null)
                {
                    if (intersection.Search(list1Node.Value))
                    {
                        break;
                    }
                    if (list1Node.Value == list2Node.Value)
                    {
                        intersection.AddToEnd(list1Node.Value);
                        break;
                    }
                    list2Node = list2Node.Next;
                }
                list1Node = list1Node.Next;
            }
            return intersection;
        }
        public static LinkedList Union(LinkedList list1, LinkedList list2)
        {
            Node list1Node = list1.Head;
            Node list2Node = list2.Head;
            LinkedList union = new LinkedList();
            while (list1Node != null)
            {
                if (!union.Search(list1Node.Value))
                {
                    union.AddToEnd(list1Node.Value);
                }
                list1Node= list1Node.Next;
            }
            while (list2Node != null)
            {
                if (!union.Search(list2Node.Value))
                {
                    union.AddToEnd(list2Node.Value);
                }
                list2Node= list2Node.Next;
            }
            return union;
        }
        public static void Scitani (LinkedList list1, LinkedList list2)
        {
            //deep copy oba seznamy
            Node list1Node = list1.Head;
            Node list2Node = list2.Head;
            LinkedList copy1 = new LinkedList();
            LinkedList copy2 = new LinkedList();
            while (list1Node != null)
            {
                copy1.AddToEnd(list1Node.Value);
                list1Node = list1Node.Next;
            }
            while (list2Node != null)
            {
                copy2.AddToEnd(list2Node.Value);
                list2Node = list2Node.Next;
            }
            LinkedList vysledek = new LinkedList();
            bool plus1 = false;
            while (true)
            {
                //posledni cifra cisel
                if (copy1.Head == null && copy2.Head == null)
                {
                    break;
                }
                if (copy1.Head == null)
                {
                    copy1.AddToEnd(0);
                }
                if (copy2.Head == null)
                {
                    copy2.AddToEnd(0);
                }
                list1Node = copy1.Head;
                list2Node = copy2.Head;
                while (list1Node.Next != null)
                {
                    list1Node = list1Node.Next;
                }
                while (list2Node.Next != null)
                {
                    list2Node = list2Node.Next;
                }
                //soucet
                int soucet = list1Node.Value + list2Node.Value;
                if (plus1)
                {
                    soucet++;
                }
                if (soucet > 9)
                {
                    soucet = soucet - 10;
                    plus1 = true;
                }
                else
                {
                    plus1 = false;
                }
                vysledek.AddToEnd(soucet);

                copy1.RemoveLast();
                copy2.RemoveLast();

            }
            //obratit vysledek
            LinkedList trueVysledek = new LinkedList();
            while (vysledek.Head != null) 
            { 
                Node currentNode = vysledek.Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                trueVysledek.AddToEnd(currentNode.Value);
                vysledek.RemoveLast();
            }
            //print
            Console.WriteLine("");
            list1.Print();
            Console.Write(" + ");
            list2.Print();
            Console.WriteLine("---------------------------------------------------------------------------");
            trueVysledek.Print();
        }
    }
    class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
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
                Console.Write(currentNode.Value + " ");
                currentNode = currentNode.Next;
            }
            Console.WriteLine("");
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
            if (Head.Next == null)
            {
                Head = null;
            }
            else 
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
        public void RemoveAll (int value)
        {   
            while (Head.Value == value)
            {
                Head = Head.Next;
            }
            Node currentNode = Head.Next;
            Node previousNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    previousNode.Next = currentNode.Next;
                    currentNode = currentNode.Next;
                }
                else
                {
                    currentNode = currentNode.Next;
                    previousNode = previousNode.Next;
                }
            }
        }
    }
}
