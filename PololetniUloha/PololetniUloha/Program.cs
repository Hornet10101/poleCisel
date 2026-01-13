using System.Text;

namespace PololetniUloha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            // (20b) 1. Seřaďte známky ze souboru znamky.txt od 1 do 5 algoritmem s lineární časovou složitostí vzhledem k počtu známek. 
            // Vypište je na řádek a pak vypište i četnosti jednotlivých známek.
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky.txt")) // otevření souboru pro čtení
            {
                int[] znamky = new int[5];

                while (!sr.EndOfStream) // dokud jsme nedošli na konec souboru
                {
                    int znamka = Convert.ToInt16(sr.ReadLine()); // čteme známky po řádcích a převádíme je na číslo
                    znamky[znamka - 1]++;

                }
                for(int i = 0; i < znamky[0]; i++)
                {
                    Console.Write("1");
                }
                PocetZnamky(znamky[0]);
                for (int i = 0; i < znamky[1]; i++)
                {
                    Console.Write("2");
                }
                PocetZnamky(znamky[1]);
                for (int i = 0; i < znamky[2]; i++)
                {
                    Console.Write("3");
                }
                PocetZnamky(znamky[2]);
                for (int i = 0; i < znamky[3]; i++)
                {
                    Console.Write("4");
                }
                PocetZnamky(znamky[3]);
                for (int i = 0; i < znamky[4]; i++)
                {
                    Console.Write("5");
                }
                PocetZnamky(znamky[4]);



            }
            // => to, co jste pravděpodobně stvořili se nazývá Counting Sort



            // (40b) 2. Ze souboru znamky_prezdivky.csv vytvořte objekty typu Student se správně přiřazenou známkou a přezdívkou.
            // Seřaďte je podle známek (stabilně = dodržte pořadí v souboru) a vypište seřazené dvojice (znamka: přezdívka) - na každý řádek jednu.
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky_prezdivky.csv"))
            {
                List<Student>[] znamkyStudentu =
                    { 
                    new List<Student>(),new List<Student>(),new List<Student>(),new List<Student>(),new List<Student>()
                    };

                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(";");
                    int cislo = Convert.ToInt16(line[1]);
                    Student student = new Student(line[0], cislo);
                    znamkyStudentu[cislo - 1].Add(student);
                }
                for (int i = 0; i < 5; i++)
                {
                    foreach (Student s in znamkyStudentu[i]) 
                    {
                        Console.WriteLine($"{s.Prezdivka};{s.Znamka}");
                    }
                }
            }
            // => to, co jste pravděpodobně stvořili se nazývá Bucket Sort (přihrádkové řazení)




            // (10b) 3. Určete časovou a prostorovou složitost algoritmu z 2. úkolu




            // (+60b) 4. BONUS: Napište kód, který bude řadit lexikograficky velká čísla v lineárním čase. Využijte dat ze souboru velka_cisla.txt

        }
        public static void PocetZnamky(int znamka)
        {
            Console.WriteLine($" celkovy pocet: {znamka}");
        }
    }

    class Student
    {
        public string Prezdivka { get; } // tím, že je zde pouze get říkáme, že tato vlastnost třídy Student jde mimo třídu pouze číst, nikoli upravovat
        public int Znamka { get; }
        public Student(string prezdivka, int znamka) // konstruktor třídy
        {
            // použitím samotného { get; } také říkáme, že tyto vlastnosti jdou nastavit nejpozději v konstruktoru - tedy v této metodě
            Prezdivka = prezdivka;
            Znamka = znamka;
        }
    }
}
