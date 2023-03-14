namespace BakeryApp
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Sum { get; private set; }

        public float Count { get; private set; }

        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public string AverageLetter
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 500:
                        return "Świetna średnia wydajność w kg";
                    case var average when average >= 400:
                        return "Bardzo dobra średnia wydajność w kg";
                    case var average when average >= 300:
                        return "Dobra średnia wydajność w kg";
                    case var average when average >= 250:
                        return "Słaba srednia wydajność w kg";
                    default:
                        return "Słaba, slaba srednia wydajność w kg";
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }

        public void AddPerformance(float performance)
        {
            this.Count++;
            this.Sum += performance;
            this.Min = Math.Min(performance, this.Min);
            this.Max = Math.Max(performance, this.Max);

        }
    }
}