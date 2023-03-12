using static BakeryApp.BakerBase;
namespace BakeryApp
{
    public interface IBaker
    {
        string Name { get; set; }

        string SurName { get; set; }

        event PerformanceAddedDelegate PerformanceAdded;

        void ShowPerformance();

        void AddPerformance(float bakerPerformance);

        void AddPerformance(string bakerPerformance);

        void AddPerformance(double bakerPerformance);

        Statistics GetStatistics();
    }
}