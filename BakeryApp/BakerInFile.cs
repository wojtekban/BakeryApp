using System;
using System.IO;
using System.Text;

namespace BakeryApp
{
    public class BakerInFile : BakerBase
    {
        public BakerInFile(string name, string surName) : base(name, surName)
        {
            fullFileName = $"{name}_{surName}{fileName}";
        }

        private const string fileName = "_wydajnosc.txt";
        private const string fileNameA = "Averenge.txt";
        private string fullFileName;

        public override event PerformanceAddedDelegate PerformanceAdded;

        public override void AddPerformance(float bakerPerformance)
        {
            using (var writer = File.AppendText($"{fullFileName}"))
            using (var writer2 = File.AppendText($"{fileNameA}"))
            {
                if (bakerPerformance > 0 && bakerPerformance <= 500)
                {
                    writer.WriteLine(bakerPerformance);
                    writer2.WriteLine($"{Name} {SurName} - {bakerPerformance}        {DateTime.UtcNow}");
                    if (PerformanceAdded != null)
                    {
                        PerformanceAdded(this, new EventArgs());
                    }
                }
                else
                {
                    throw new Exception("Proszę wybrać wydajność w kg z przedziału od 0 do 500");
                }
            }
        }

        public override void AddPerformance(string bakerPerformance)
        {
            if (float.TryParse(bakerPerformance, out float result))
            {
                this.AddPerformance(result);
            }
            else
            {
                throw new Exception("string in not float");
            }
        }

        public override void AddPerformance(double bakerPerformance)
        {
            float result = (float)bakerPerformance;
            this.AddPerformance(result);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        result.AddPerformance(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }

        public override void ShowPerformance()
        {
            StringBuilder sb = new StringBuilder($"{this.Name} {this.surName} wszystkie wydajności w kg: ");

            using (var reader = File.OpenText(($"{fullFileName}")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    sb.Append($"{line}; ");
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine($"\n{sb}");
        }
    }
}