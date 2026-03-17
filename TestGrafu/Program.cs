namespace TestGrafu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int[,] matSousednosti = new int[num,num];
            int start = DoMatice(matSousednosti);
            int goal = Convert.ToInt32(Console.ReadLine());
            PrintMatici(matSousednosti, num);

            BFS(matSousednosti, num, start, goal);

        }
        public static void BFS(int[,] matSousednosti, int num, int start, int goal)
        {
            start = start - 1;
            goal = goal - 1; //indexy v arrayich
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            int[] predchudci = new int[num];
            
            while (queue.Count != 0)
            {   
                int point = queue.Dequeue();
                for(int i = 0; i < num; i++)
                {
                    if (matSousednosti[point,i] == 1)
                    {
                        queue.Enqueue(i);
                        predchudci[i] = point;
                    }
                }
            }
            UsporadaniCesty(predchudci, start, goal);
        }
        public static void UsporadaniCesty(int[] predchudci, int start, int goal)
        {
            List<int> cesta = new List<int>();
            cesta.Add(goal+1);
            int temp = goal;
            while (temp != start)
            {
                if (predchudci[temp] == 0)
                {
                    cesta.Add(0);
                    break;
                }
                else
                {
                    cesta.Add(predchudci[temp] + 1);
                    temp = predchudci[temp];
                }
            }
            VypsaniCesty(cesta);
        }
        public static void VypsaniCesty(List<int> cesta)
        {
            if (cesta.Contains(0))
            {
                Console.WriteLine("neexistuje");
            }
            else
            {
                for (int i = cesta.Count; i > 0; i--)
                {
                    Console.Write(cesta[i - 1]);
                }
            }
        }
        public static int DoMatice(int[,] matSousednosti)
        {
            while(true)
            {
                string input = Console.ReadLine();
                if(input.Length > 2)
                {
                    int[] entry = Array.ConvertAll(input.Trim().Split(), int.Parse);
                    matSousednosti[entry[0]-1, entry[1]-1] = 1;
                }
                else
                {
                    int start = Convert.ToInt32(input);
                    return start;
                }
            }
        }
        public static void PrintMatici(int[,] matSousednosti, int num)
        {
            for(int i = 0; i < num; i++)
            {
                for(int j = 0; j < num; j++)
                {
                    Console.Write(matSousednosti[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
