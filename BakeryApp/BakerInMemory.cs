using System.Text;

namespace BakeryApp
{
    public class BakerInMemory : BakerBase
    {
        private List<float> performance = new List<float>();
        public override event PerformanceAddedDelegate PerformanceAdded;

        public BakerInMemory(string name, string surName)
            : base(name, surName)
        {
        }

        public override void ShowPerformance()
        {
            StringBuilder sb = new StringBuilder($"{this.Name} {this.SurName} wszystkie wydajności w kg: ");
            for (int i = 0; i < performance.Count; i++)
            {
                if (i == performance.Count - 1)
                {
                    sb.Append($"{performance[i]}.");
                }
                else
                {
                    sb.Append($"{performance[i]}; ");
                }
            }
            Console.WriteLine($"\n{sb}");
        }

        public override void AddPerformance(float bakerPerformance)
        {
            if (bakerPerformance >= 0 && bakerPerformance <= 500)
            {
                this.performance.Add(bakerPerformance);

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
            var statistics = new Statistics();

            foreach (var bakerPerformance in this.performance)
            {
                statistics.AddPerformance(bakerPerformance);
            }
            return statistics;
        }
    }
}