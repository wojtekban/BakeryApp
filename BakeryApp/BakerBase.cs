namespace BakeryApp
{
    public abstract class BakerBase : Person, IBaker
    {
        public delegate void PerformanceAddedDelegate(object sender, EventArgs args);
        public abstract event PerformanceAddedDelegate PerformanceAdded;      
        public  string name;
        public string surName;

        public override string Name
        {
            get
            {
                return $"{char.ToUpper(name[0])}{name.Substring(1, name.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }

        public override string SurName
        {
            get
            {
                return $"{char.ToUpper(surName[0])}{surName.Substring(1, surName.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    surName = value;
                }
            }
        }

        public BakerBase(string name, string surName) : base(name, surName)
        {
            this.Name = name;
            this.SurName = surName;
        }

        public abstract void ShowPerformance();

        public abstract void AddPerformance(float bakerPerformance);

        public abstract void AddPerformance(string bakerPerformance);

        public abstract void AddPerformance(double bakerPerformance);

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count != 0)
            {
                ShowPerformance();
                Console.WriteLine($"{Name} {SurName} statistics w kg:");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Ilość wydajności wzięta do obliczeń.: {stat.Count}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Największa wydajność: {stat.Max:N2} kg");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Najmniejsza wydajność: {stat.Min:N2} kg");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Średnia wydajność: {stat.Average:N2} kg");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Średnia: {stat.AverageLetter:N2}");
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Nie można uzyskać żadnych statystyk dla {this.Name} {this.SurName} ponieważ, żadne wydajności nie zostały dodane.");
                Console.ResetColor();
            }
        }
    }
}