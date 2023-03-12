using System;
namespace BakeryApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            WritelineColor(ConsoleColor.Magenta, "Witam w systemie rejestrowania wydajności i obliczania statystyk dla małych piekarni. ");
            WritelineColor(ConsoleColor.DarkMagenta, "================================================================================");
            Console.WriteLine();

            bool CloseApp = false;

            while (!CloseApp)
            {
                Console.WriteLine();
                WritelineColor(ConsoleColor.Cyan,
                     "1 - Dodaje produkcję dzienną piekarza w kg, obliczaną w pamięci i wyświetl statystyki\n" +
                     "2 - Dodaje produkcję dzienną piekarza w kg, obliczaną i zapisaną w pliku .txt i wyświetl statystyki\n" +
                     "X - Zamknij app\n");

                WritelineColor(ConsoleColor.Yellow, "Proszę wybrac system obliczania? \n Wybierz 1, 2 lub X: ");

                var bakerInput = Console.ReadLine().ToUpper();

                switch (bakerInput)
                {
                    case "1":
                        AddPerformanceBakeryInMemory();
                        break;

                    case "2":
                        AddPerformanceBakeryInFile();
                        break;

                    case "X":
                        CloseApp = true;
                        break;

                    default:
                        WritelineColor(ConsoleColor.Red, "Zły wybór.Spróbuj jeszcze raz.\n");
                        continue;
                }
            }
            WritelineColor(ConsoleColor.DarkYellow, "\n\nKończymy na dziś. Zapraszam ponownie.");
            Console.ReadKey();
        }

        private static void WritelineColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void BakeryPerformanceAdded(object sender, EventArgs args)
        {
            WritelineColor(ConsoleColor.DarkYellow, $"Dopisano produkcję dzienną piekarza w kg!");
        }

        private static void AddPerformanceBakeryInMemory()
        {
            string name = GetValueFromBaker("Podaj imię piekarza: ");
            string surName = GetValueFromBaker("Podaj nazwisko piekarza: ");
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surName))
            {
                var inMemoryBaker = new BakerInMemory(name, surName);
                inMemoryBaker.PerformanceAdded += BakeryPerformanceAdded;
                BakerPerformanceAdded(inMemoryBaker);
                inMemoryBaker.ShowStatistics();
            }
            else
            {
                WritelineColor(ConsoleColor.Red, "Brak danych, wprowadź jeszcze raz");
            }
        }

        private static void AddPerformanceBakeryInFile()
        {
            string name = GetValueFromBaker("Podaj imię piekarza: ");
            string surName = GetValueFromBaker("Podaj nazwisko piekarza: ");
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surName))
            {
                var inFileBakery = new BakerInFile(name, surName);
                inFileBakery.PerformanceAdded += BakeryPerformanceAdded;
                BakerPerformanceAdded(inFileBakery);
                inFileBakery.ShowStatistics();
            }
            else
            {
                WritelineColor(ConsoleColor.Red, "Pracownik nie istnieje!, Spróbuj jeszcze raz");
            }
        }

        private static void BakerPerformanceAdded(IBaker baker)
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, $"Wprowadź produkcje dzienną {baker.Name} {baker.SurName} w kg:");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    baker.AddPerformance(input);
                }
                catch (Exception ex)
                {
                    WritelineColor(ConsoleColor.Red, ex.Message);
                }
                finally
                {
                    WritelineColor(ConsoleColor.DarkMagenta, $"Dopisz kolejną wage w kg {baker.Name} {baker.SurName} lub wyświetl statystyki 'q'.");
                }
            }
        }

        private static string GetValueFromBaker(string comment)
        {
            WritelineColor(ConsoleColor.Yellow, comment);
            string bakerInput = Console.ReadLine();
            return bakerInput;
        }
    }
}