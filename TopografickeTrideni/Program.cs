using System.ComponentModel;

namespace TopografickeTrideni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //jit po prvnich pismenech, ty se predchazeji, pak po druhych, tretich, atd...
            string[] words = RozdeleniSlov();
            int maxLength = getLongestWordLen(words);
            List<string> vztahy = new List<string>(); // napr. ab znamena a predchazi b
            
            for(int i = 0; i < maxLength; i++)
            {
                int numWords = words.Length;
                List<char> letters = new List<char>();

                for (int j = 0; j < numWords; j++) //vytvori seznam prvnich/druhych (podle i) atd. pismen
                {
                    try
                    {
                        if (!letters.Contains(words[j][i]))
                        {
                            letters.Add(words[j][i]);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }


                for (int j = 0; j < letters.Count-1; j++) 
                {
                    if (letters[j] != letters[j + 1])
                    {
                        string vztah = letters[j].ToString() + letters[j+1].ToString();
                        Console.WriteLine(vztah);
                        Console.WriteLine("");
                        vztahy.Add(vztah);
                    }
                }
            }
            printList(vztahy);

        }
        public static int getLongestWordLen(string[] words)
        {
            int maxNum = 0;
            foreach (string word in words)
            {
                if (word.Length > maxNum)
                {
                    maxNum = word.Length;
                }
            }
            return maxNum;
        }

        public static string[] RozdeleniSlov()
        {
            string entry = Console.ReadLine();
            string[] words = entry.Split();
            return words;
        }
        public static void printList(List<string> list)
        {
            foreach (string word in list)
            {
                Console.Write(word);
            }
        }
    }
}
