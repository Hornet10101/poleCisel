namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 9, 45, 98, 20, 74, 6, 100 };
            arr = QuickSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public static int[] QuickSort(int[] array)
        {
            if(array.Length <= 1)
            {
                return array;
            }
            Random random = new Random();
            int pivot = array[random.Next(0, array.Length)];
            
            List<int> right = new List<int>();
            List<int> left = new List<int>();
            List<int> center = new List<int>();


            foreach(int item in array)
            {
                if(item > pivot)
                {
                    right.Add(item);
                }
                else if(item < pivot)
                {
                    left.Add(item);
                }
                else
                {
                    center.Add(item);
                }
            }
            int[] leftArray = left.ToArray();
            int[] centerArray = center.ToArray();
            int[] rightArray = right.ToArray();

            if(leftArray.Length > 1)
            {
                leftArray = QuickSort(leftArray);
            }
            if(rightArray.Length > 1)
            {
                rightArray = QuickSort(rightArray);
            }

            int[] result = new int[leftArray.Length + centerArray.Length + rightArray.Length];
            Array.Copy(leftArray, result, leftArray.Length);
            Array.Copy(centerArray, 0, result, leftArray.Length, centerArray.Length);
            Array.Copy(rightArray, 0, result, leftArray.Length + centerArray.Length, rightArray.Length);
            return result;

        }
    }
}
