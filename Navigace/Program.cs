namespace Navigace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mesta;
            int pocetCest;
            int[,,] matice; //3. dimenze matice - 0 -> neplacena, 1 -> placena
            while (true)
            {
                string ukol = Console.ReadLine();
                string[] zadani = ukol.Split();
                if (zadani.Length == 2)
                {
                    try
                    {
                        mesta = Convert.ToInt32(zadani[0]);
                        pocetCest = Convert.ToInt32(zadani[1]);
                        matice = new int[mesta, mesta, 2];
                        break;

                    }
                    catch
                    {
                        Console.WriteLine("Neplatný vstup");
                    }
                }
                else
                {
                    Console.WriteLine("Neplatný vstup");
                }

            }
            int mesto1;
            int mesto2;
            int delka;
            int otevrenost;
            for (int i = 0; i < pocetCest; i++)
            {
                string cesta = Console.ReadLine();
                string[] dataCesty = cesta.Split();
                if (dataCesty.Length == 4)
                {
                    try
                    {
                        mesto1 = Convert.ToInt32(dataCesty[0]);
                        mesto2 = Convert.ToInt32(dataCesty[1]);
                        delka = Convert.ToInt32(dataCesty[2]);
                        otevrenost = Convert.ToInt32(dataCesty[3]);
                        if (mesto1 < 0 || mesto2 < 0 || delka < 0 || !(otevrenost == 0 || otevrenost == 1))
                        {
                            Console.WriteLine("neplatný vstup");
                        }
                        else
                        {
                            matice[mesto1, mesto2, 0] = delka;
                            matice[mesto1, mesto2, 1] = otevrenost;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Neplatný vstup");
                    }
                }
                else 
                {
                    Console.WriteLine("Neplatný vstup");
                    i--;
                }
            }

            int start;
            int target;
            while (true)
            {
                string draha = Console.ReadLine();
                string[] startTarget = draha.Split();
                if (startTarget.Length == 2)
                {
                    try
                    {
                        start = Convert.ToInt32(startTarget[0]);
                        target = Convert.ToInt32(startTarget[1]);
                        break;
                    }
                    catch 
                    {
                        Console.WriteLine("Neplatný vstup");
                    }
                }
                else
                {
                    Console.WriteLine("Neplatný vstup");
                }
            }
            DijkstruvAlg(mesta, matice, start, target);
        } //Dijkstruv Algoritmus

        public static int smartConvert(string entry, int min, int max)
        {
            int num;
            if (!int.TryParse(entry, out num))
            {
                Console.WriteLine("Neplatny vstup");
                return -1;
            }
            if (num < min || num > max)
            {
                Console.WriteLine("Neplatny vstup");
                return -1;
            }
            return num;
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
                    if (nextDistance > 0 && stav[i] != 2 && distance[i] > distance[activePointIndex] + nextDistance) //pokud cesta existuje, dalsi mesto neni uzavrene a nova cesta je rychlejsi
                    {
                        if (predchudce[activePointIndex] != null) //pokud predchudce existuje(neni to prvni mesto)
                        {
                            if (matice[(int)predchudce[activePointIndex], activePointIndex, 1] == 1 && matice[activePointIndex, i, 1] == 1)
                            { //pokud je predchozi i nynejsi cesta placena, momentalni mesto neprohledame
                            }
                            else if (matice[(int)predchudce[activePointIndex], activePointIndex, 1] == 1)
                            { //pokud jen predchozi je placena, oznacit nynejsi jako placenou
                              // -> az bude dalsi placena, predchozi if statement se aktivuje
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
                {//vypise cestu
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