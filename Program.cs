using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace poleCisel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pole = {0,1,2,3,4,5,6,7,8,9,10};
            int max = FindMax(pole);
            int[] sortedPole = Sort(pole);
            Console.WriteLine($"{max}");
            WriteList( sortedPole );
            Console.WriteLine("Jake cislo chcete najit?");
            int target = Convert.ToInt32(Console.ReadLine());
            int search = BinarySearch(sortedPole, target);
            Console.WriteLine($"{search}");
            Console.WriteLine("hi");
            
        }
        public static int FindMax(int[] pole)
        {
            int max = 0;
            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i] > max)
                {
                    max = pole[i];
                }
            }
            return max;
        }
        public static int[] Sort(int[] pole) {
            while (true)
            {
                int swaps = 0;
                for (int i = 0; i < pole.Length - 1; i++)
                {
                    int tempA = pole[i];
                    int tempB = pole[i + 1];
                    if (tempB > tempA)
                    {
                        pole[i] = tempB;
                        pole[i + 1] = tempA;
                        swaps++;
                    }
                }
                if (swaps == 0)
                {
                    return pole;
                }
            }

        }
        public static int BinarySearch(int[] pole, int target)
        {
            int index = pole.Length/2;
            int change = index;
            while (true)
            {
                if (index - 1 > pole.Length || index - 1 < 0)
                {
                    return -1;
                }
                if (pole[index - 1] == target)
                {
                    return index;
                }
                else if (pole[index - 1] < target)
                {
                    if (change % 2 != 0 && change != 1)
                    {
                        change = (change - 1) / 2;
                        index = index - change;
                    }
                    else if (change == 1)
                    {
                        index = index - 1;
                    }
                    else
                    {
                        change = index / 2;
                        index = index - change;
                    }
                }
                else
                {
                    if (change % 2 != 0 && change != 1)
                    {
                        change = (change - 1) / 2;
                        index = index + change;
                    }
                    else if (change == 1)
                    {
                        index = index + 1;
                    } else
                    {   
                        change = change / 2;
                        index = index + change;
                    }
                }
            }
        }
        public static void WriteList(int[] pole)
        {
            for (int i = 0; i < pole.Length; i++)
            {
                Console.Write(pole[i]);
                Console.Write(' ');
            }
            Console.WriteLine(" ");
        }
    }
}
