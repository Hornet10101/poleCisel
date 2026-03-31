namespace BogoSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 1, 5, 4, 9, 7, 8};
            PrintArr(arr);
            PrintArr(BogoSort(arr));
        }
        public static void PrintArr(int[] arr)
        {
            for(int i  = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        public static int[] BogoSort(int[] arr)
        {
            int attempts = 0;
            while (!IsSorted(arr))
            {
                if (arr.Length <= 1)
                {
                    return arr;
                }
                Shuffle(arr);
                attempts++;
            }
            Console.WriteLine(attempts);
            return arr;
        }
        public static int[] Shuffle(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Random rand = new Random();
                int y = rand.Next(0, arr.Length);
                int temp = arr[i];
                arr[i] = arr[y];
                arr[y] = temp;
            }
            return arr;
        }
        public static bool IsSorted(int[] arr)
        {
            for(int i  = 1; i < arr.Length; i++)
            {
                if(arr[i-1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
