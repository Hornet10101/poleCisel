using System.Xml.Serialization;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int bod1x;
                string point1x = Console.ReadLine();
                if (point1x == "q")
                {
                    break;
                }
                else
                {
                    bod1x = Convert.ToInt32(point1x);
                }
                int bod1y = Convert.ToInt32(Console.ReadLine());
                int bod2x = Convert.ToInt32(Console.ReadLine());
                int bod2y = Convert.ToInt32(Console.ReadLine());
                int bod3x = Convert.ToInt32(Console.ReadLine());
                int bod3y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                double stranaA = Vzdalenost(bod1x, bod1y, bod2x, bod2y);
                double stranaB = Vzdalenost(bod3x, bod3y, bod2x, bod2y);
                double stranaC = Vzdalenost(bod1x, bod1y, bod3x, bod3y);

                trojNerovnost(stranaA, stranaB, stranaC);
            }
        }
        public static double Vzdalenost(int bod1x, int bod1y, int bod2x, int bod2y)
        {
            int vzdalenostX = bod1x - bod2x;
            int vzdalenostY = bod1y - bod2y;
            double vzdalenost = Math.Sqrt(Math.Pow(vzdalenostX, 2) + Math.Pow(vzdalenostY, 2));
            return vzdalenost;
        }
        public static void trojNerovnost(double A, double B, double C) 
        {
            if (A + B <= C || A + C <= B || B + C <= A)
            {
                Console.WriteLine("Tyto tři body netvoří trojúhelník");
            }
            else
            {
                Console.WriteLine(A);
                Console.WriteLine(B);
                Console.WriteLine(C);
            }
        }
    }
}
