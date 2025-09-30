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
            int[] pole = { 1, 2, 3, 9, 7 , 11 };
            int max = FindMax(pole);
            int[] sortedPole = Sort(pole);
            int search = BinarySearch(sortedPole, 11);
            Console.WriteLine($"{max}");
            WriteList( sortedPole );
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
        public static int BinarySearch(int[] pole, int num)
        {
            int len = pole.Length /2;
            int limit = len / 2 + 1;
            int count = 0;
            while (true)
            {
                if (pole[len] == num)
                {
                    return len;
                }
                else if (pole[len] < num)
                {
                    len = len - len / 2;
                }
                else
                {
                    len = len + len / 2;
                }
                if (count == limit)
                {
                    return -1;
                }
                count++;
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
