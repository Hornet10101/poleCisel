namespace absolutniKino
{
    using System.Text;

    internal class Program
    {
        const int PocetRad = 8;
        const int PocetSedacek = 10;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string[,] maticeSedadel = new string[PocetSedacek,PocetRad];
            List<int> zakoupeneRady = new List<int>(); 
            List <int> zakoupeneSedacky = new List <int>();
            for (int i = 0; i < PocetRad; i++)
            {
                for (int j = 0; j < PocetSedacek; j++)
                {
                    maticeSedadel[j, i] = "□";
                }
            }

            fillHall(maticeSedadel); //zaplni nahodna mista
            while (true)
            {
                int action = actionInterface();
                if(action == 1)
                {
                    zobrazitSal(maticeSedadel);
                }
                else if(action == 2)
                {
                    udelatRezervaci(maticeSedadel, zakoupeneSedacky, zakoupeneRady);
                }
                else if(action == 3)
                {
                    zrusitRezervaci(maticeSedadel, zakoupeneSedacky, zakoupeneRady);
                }
                else if(action == 4)
                {
                    showRezervace(zakoupeneSedacky, zakoupeneRady);
                    backToMenu();
                }
                else if(action == 5)
                {
                    zaplaceni(zakoupeneRady);
                }
                else if (action == 6)
                {
                    break;
                }
            }
        }
        public static int actionInterface()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Vítejte v našem kině! Vyberte akci:");
            Console.WriteLine("1 - zobrazit místa v kinosálu");
            Console.WriteLine("2 - rezervovat místo");
            Console.WriteLine("3 - zrušit rezervaci");
            Console.WriteLine("4 - zobrazit vase rezervace");
            Console.WriteLine("5 - zaplaceni");
            Console.WriteLine("6 - ukončit program");
            Console.WriteLine("");
            int akce = loadNumber(1,6);
            Console.WriteLine("-----------------------------------");
            return akce;
        }
        public static void zobrazitSal(string[,] maticeSedadel)
        {
            Console.WriteLine("  _________  ");
            Console.WriteLine(@" /| | | | |\  ");
            Console.WriteLine("");

            for (int i = 0; i < PocetRad; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < PocetSedacek; j++)
                {
                    if(j == PocetSedacek/2)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(maticeSedadel[j, i]);
                }
                Console.WriteLine("");
            }
            backToMenu();
        }

        public static void udelatRezervaci(string[,] maticeSedadel, List<int> zakoupeneSedacky, List<int> zakoupeneRady)
        {
            while (true)
            {
                int vybranaRada = getCisloRady("zarezervovat");
                int vybranaSedacka = getCisloSedacky("zarezervovat");
                if (maticeSedadel[vybranaSedacka - 1, vybranaRada - 1] == "□")
                {
                    maticeSedadel[vybranaSedacka - 1, vybranaRada - 1] = "■";
                    Console.WriteLine("Uspech! Rezervace budou bez zaplaceni automaticky zruseny pri opusteni programu");
                    zakoupeneRady.Add(vybranaRada);
                    zakoupeneSedacky.Add(vybranaSedacka);
                    break;
                }
                else
                {
                    Console.WriteLine("Misto neni volne!");
                }
            }
            backToMenu();
        }
        public static void zrusitRezervaci(string[,] maticeSedadel, List<int> zakoupeneSedacky, List<int> zakoupeneRady)
        {
            showRezervace(zakoupeneSedacky, zakoupeneRady);
            if (zakoupeneRady.Count == 0)
            {
                backToMenu();
            }
            else
            {
                int cisloRezervace = getCisloRezervace(zakoupeneRady);
                if (cisloRezervace == 0)
                {
                    Console.WriteLine("OK!");
                    backToMenu();
                }
                else
                {
                    maticeSedadel[zakoupeneSedacky[cisloRezervace - 1] - 1, zakoupeneRady[cisloRezervace - 1] - 1] = "□";
                    zakoupeneSedacky.RemoveAt(cisloRezervace - 1);
                    zakoupeneRady.RemoveAt(cisloRezervace - 1);
                    Console.WriteLine("Rezervace zrusena!");
                    backToMenu();
                }
            }
        }

        public static void zaplaceni(List<int> zakoupeneRady)
        {
            int cena = 0;
            int pocetVIPPriplatku = 0;
            for (int i = 0; i < zakoupeneRady.Count; i++)
            {
                cena += 180;
                if(zakoupeneRady[i] >= 7)
                {
                    pocetVIPPriplatku++;
                    cena += 70;
                }
            }
            int pocetNormalnichListku = zakoupeneRady.Count - pocetVIPPriplatku;
            Console.WriteLine("VYUCTOVANI");
            Console.WriteLine($"Normalni listky: {pocetNormalnichListku}");
            Console.WriteLine($"{pocetNormalnichListku}*180 = {pocetNormalnichListku * 180}");
            Console.WriteLine($"VIP listky: {pocetVIPPriplatku}");
            Console.WriteLine($"{pocetVIPPriplatku}*250 = {pocetVIPPriplatku * 250}");
            Console.WriteLine($"Celkem: {cena}");
            Console.WriteLine("Dekujeme za nakup!");
            backToMenu();
        }
        public static void fillHall(string[,] maticeSedacek)
        {
            Random random = new Random();
            int num_people = random.Next(2,40);
            for (int i = 0; i < num_people; i++)
            {
                int rada = random.Next(1,PocetRad);
                int sedacka = random.Next(1,PocetSedacek);

                maticeSedacek[sedacka, rada] = "■";
            }
        }
        public static void showRezervace(List<int> zakoupeneSedacky, List<int> zakoupeneRady)
        {
            if (zakoupeneRady.Count == 0)
            {
                Console.WriteLine("Nemate zadne rezervace!");
            }
            else
            {
                Console.WriteLine("Vase rezervace:");
                for (int i = 0; i < zakoupeneRady.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Rada {zakoupeneRady[i]}, sedacka {zakoupeneSedacky[i]}");
                }
            }
        }
        public static int getCisloRezervace(List<int> zakoupeneRady)
        {
            Console.WriteLine("Kterou rezervaci si prejete zrusit?");
            Console.WriteLine("VAROVANI: Penize za jiz zaplacene rezervace se nevraci. Pokud jste zmenili nazor, napiste cislo 0");
            int cisloRezervace = loadNumber(1,zakoupeneRady.Count);
            return cisloRezervace;
        }

        public static void backToMenu()
        {
            Console.WriteLine("Stisknete Enter pro vraceni do menu");
            var backToMenu = Console.ReadKey();
            while (backToMenu.Key != ConsoleKey.Enter)
            {
                backToMenu = Console.ReadKey();
            }
        }
        public static int getCisloRady(string akce)
        {
            Console.WriteLine($"Kterou radu chcete {akce}? 1-8");
            int vybranaRada = loadNumber(1, 8);
            return vybranaRada;
        }
        public static int getCisloSedacky(string akce)
        {
            Console.WriteLine($"Kterou sedacku chcete {akce}? 1-10");
            int vybranaSedacka = loadNumber(1, 10);
            return vybranaSedacka;
        }
        public static int loadNumber(int min, int max)
        {
            int num;
            if (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Neplatny vstup");
                num = loadNumber(min, max);
            }
            if (num < min || num > max)
            {
                Console.WriteLine("Neplatny vstup");
                num = loadNumber(min, max);
            }
            return num;
        }
    }
}
