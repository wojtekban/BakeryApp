using static BakeryApp.BakeryBase;
namespace BakeryApp
{
    public interface IBakery
    {
        string Name { get; set;}
        string SurName { get; set; }

        event PerformanceAddedDelegate PerformanceAdded;

        void ShowPerformance();

        void AddPerformance(float bakerPerformance);

        void AddPerformance(string bakerPerformance);

        void AddPerformance(double bakerPerformance);

        Statistics GetStatistics();

    }
}