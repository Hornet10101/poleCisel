namespace Navigace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mesta;
            int pocetCest;
            int[,,] matice;
            while (true)
            {
                string ukol = Console.ReadLine();
                if (ukol.Length == 3)
                {
                    string[] zadani = ukol.Split();
                    if (zadani.Length == 2)
                    {
                        mesta = Convert.ToInt32(zadani[0]);
                        pocetCest = Convert.ToInt32(zadani[1]);
                        matice = new int[mesta, mesta, 2];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Cesta neexistuje");
                    }

                }
                else
                {
                    Console.WriteLine("Cesta neexistuje");
                }
            }


            int mesto1;
            int mesto2;
            int delka;
            int otevrenost;
            for (int i = 0; i < pocetCest; i++)
            {
                string cesta = Console.ReadLine();
                if (cesta.Length == 7)
                {
                    string[] dataCesty = cesta.Split();
                    if (dataCesty.Length == 4)
                    {
                        mesto1 = Convert.ToInt32(dataCesty[0]);
                        mesto2 = Convert.ToInt32(dataCesty[1]);
                        delka = Convert.ToInt32(dataCesty[2]);
                        otevrenost = Convert.ToInt32(dataCesty[3]);
                        matice[mesto1, mesto2, 0] = delka;
                        matice[mesto1, mesto2, 1] = otevrenost;
                    }
                    else 
                    {
                        Console.WriteLine("Cesta neexistuje");
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine("Cesta neexistuje");
                    i--;
                }

            }

            int start;
            int target;
            while (true)
            {
                string draha = Console.ReadLine();
                if (draha.Length == 3)
                {
                    string[] startTarget = draha.Split();
                    if (startTarget.Length == 2)
                    {
                        start = Convert.ToInt32(startTarget[0]);
                        target = Convert.ToInt32(startTarget[1]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Cesta neexistuje");
                    }
                }
                else
                {
                    Console.WriteLine("Cesta neexistuje");
                }
            }
            DijkstruvAlg(mesta, matice, start, target);
        } //Dijkstruv Algoritmus

        public static void getGraph()
        {

        }
        public class Bod(int index, int distance, int stav, int indexPredchudce) //nakonec nevyuzivam
        {
            public int index = index;
            public int distance = distance;
            public int stav = stav;
            public int indexPredchudce = indexPredchudce;
        }

        public static void DijkstruvAlg(int maticeSize, int[,,] matice, int start, int target)
        {
            PriorityQueue<int, int?> otevreneVrcholy = new PriorityQueue<int, int?>();
            int?[] stav = new int?[maticeSize];//0-nenalezeny, 1-otevreny, 2-uzavreny
            for (int i = 0; i < maticeSize; i++)
            {
                stav[i] = 0;
            }

            int?[] predchudce = new int?[maticeSize];

            int?[] distance = new int?[maticeSize];
            for (int i = 0; i < maticeSize; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[start] = 0;
            otevreneVrcholy.Enqueue(start, distance[start]);
            stav[start] = 1;

            while (true)
            {
                int activePointIndex = otevreneVrcholy.Peek();
                for (int i = 0; i < maticeSize; i++)
                {
                    int nextDistance = matice[activePointIndex, i, 0];
                    if (nextDistance > 0 && stav[i] != 2 && distance[i] > distance[activePointIndex] + nextDistance)
                    {
                        if (predchudce[activePointIndex] != null)
                        {
                            if (matice[(int)predchudce[activePointIndex], activePointIndex, 1] == 1 && matice[activePointIndex, i, 1] == 1)
                            {
                                distance[i] = int.MaxValue;
                            }
                            else if (matice[(int)predchudce[activePointIndex], activePointIndex, 1] == 1)
                            {
                                matice[activePointIndex, i, 1] = 1;
                                stav[i] = 1;
                                distance[i] = distance[activePointIndex] + nextDistance;
                                predchudce[i] = activePointIndex;
                                otevreneVrcholy.Enqueue(i, distance[i]);
                            }
                            else
                            {
                                stav[i] = 1;
                                distance[i] = distance[activePointIndex] + nextDistance;
                                predchudce[i] = activePointIndex;
                                otevreneVrcholy.Enqueue(i, distance[i]);
                            }
                        }
                        else
                        {
                            stav[i] = 1;
                            distance[i] = distance[activePointIndex] + nextDistance;
                            predchudce[i] = activePointIndex;
                            otevreneVrcholy.Enqueue(i, distance[i]);
                        }
                    }
                }

                otevreneVrcholy.Dequeue();
                stav[activePointIndex] = 2;
                if (activePointIndex == target)
                {
                    Console.WriteLine();
                    List<int> cesta = new List<int>();
                    int predtim = target;
                    while (predchudce[predtim] != null)
                    {
                        cesta.Add(predtim);
                        predtim = (int)predchudce[predtim];
                    }
                    Console.Write(start);
                    for (int i = cesta.Count - 1; i >= 0; i--)
                    {
                        Console.Write(" -> ");
                        Console.Write(cesta[i]);
                    }

                    Console.WriteLine();
                    Console.WriteLine(distance[activePointIndex]);
                    break;
                }
            }
        }
    }
}