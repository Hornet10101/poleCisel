namespace retizekPratelstvi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lidi = Convert.ToInt32(Console.ReadLine());
            string spojnice = Console.ReadLine();
            string cil = Console.ReadLine();
            string[] dvojice = spojnice.Split();

            string[] path = cil.Split();
            int start = Convert.ToInt32(path[0]);
            int target = Convert.ToInt32(path[1]);

            int[,] matice = new int[lidi,lidi];

            for (int i = 0; i < dvojice.Length; i++)
            {
                string[] rozdeleni = dvojice[i].Split("-");
                int vrchol1 = Convert.ToInt32(rozdeleni[0]);
                int vrchol2 = Convert.ToInt32(rozdeleni[1]);

                matice[vrchol1-1, vrchol2-1] = 1;
                matice[vrchol2-1, vrchol1-1] = 1;
            }
            for (int i = 0; i < lidi; i++) 
            {
                for (int j = 0; j < lidi; j++)
                {
                    Console.Write(matice[i,j]);
                }
                Console.WriteLine();
            }
            PathSearch(lidi, matice, start, target);
        }
        public static void PathSearch(int maticeSize, int[,] matice,int start, int target)
        {
            Queue<int> otevreneVrcholy = new Queue<int>();
            // otevreneVrcholy.Enqueue(1);
            // otevreneVrcholy.Dequeue();
            // otevreneVrcholy.Peek();
            int?[] stav = new int?[maticeSize];//0-nenalezeny, 1-otevreny, 2-uzavreny
            for(int i = 0; i < maticeSize; i++)
            {
                stav[i] = 0;
            }

            List<int> predchudce = new List<int>();
            for (int i = 0; i < maticeSize; i++)
            {
                predchudce.Add(0);
            }

            otevreneVrcholy.Enqueue(start);

            stav[start-1] = 1;
            int distance = 0;
            List<int> cesta = new List<int>();
            bool found = false;

            while (otevreneVrcholy.Count > 0)
            {

                int pointIndex = otevreneVrcholy.Peek() - 1;
                for (int i = 0; i < maticeSize; i++)
                {
                    if (matice[pointIndex, i] == 1 && stav[i] == 0)
                    {
                        otevreneVrcholy.Enqueue(i + 1);
                        stav[i] = 1;
                        predchudce[i] = otevreneVrcholy.Peek();
                    }
                }
                if (otevreneVrcholy.Peek() == target)
                {
                    int predtim = target;
                    while (predtim != start)
                    {
                        cesta.Add(predtim);
                        predtim = predchudce[predtim-1];
                        distance++;
                    }
                    Console.Write(start);
                    for(int i = cesta.Count-1; i >= 0; i--)
                    {
                        Console.Write(cesta[i]);
                    }
                    found = true;
                }
                stav[pointIndex] = 2;
                otevreneVrcholy.Dequeue();

            }
            if (found == false)
            {
                Console.WriteLine("neexistuje");
            }
        }
    }
}
