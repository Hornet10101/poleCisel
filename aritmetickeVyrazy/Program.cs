namespace aritmetickeVyrazy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nums = Console.ReadLine();
            string[] arr = nums.Split();

            Stack<float> stack = new Stack<float>();

            int i = 0;

            while (i != arr.Length)
            {
                if (float.TryParse(arr[i], out float num))
                {
                    stack.Push(num);
                }
                else
                {
                    if(stack.Count < 2)
                    {
                        Console.WriteLine("Neplatný výraz: chybí operand/y");
                        break;
                    }
                    float right = stack.Pop();
                    float left = stack.Pop();
                    if(right == 0 && arr[i] == "/")
                    {
                        Console.WriteLine("Deleni nulou!");
                        break;
                    }
                    stack.Push(mathOperation(left, right, arr[i]));
                }
                i++;
                if(i == arr.Length)
                {
                    if(stack.Count > 1)
                    {
                        Console.WriteLine("Neplatný výraz: chybí operátor/y");
                        break;
                    }
                    Console.WriteLine(stack.Pop());
                }
            }
        }
        public static float mathOperation(float left, float right, string op)
        {
            if(op  == "+")
            {
                return left + right;
            }
            else if (op == "-")
            {
                return left - right;
            }
            else if(op == "*")
            {
                return left * right;
            }
            else
            {
                return left / right;
            }
        }
    }
}
