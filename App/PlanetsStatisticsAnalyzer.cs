public class PlanetsStatisticsAnalyzer : IPlanetsStatisticsAnalyzer
{
    private readonly IPlanetsStatsUserInteractor _planetsUserInteractor;

    public PlanetsStatisticsAnalyzer(IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsUserInteractor = planetsStatsUserInteractor;
    }

    public void Analyze(IEnumerable<Planet> planets)
    {
        var propertyNamesToSelectorsMapping =
             new Dictionary<string, Func<Planet, int?>>()
             {
                 ["population"] = planet => planet.Population,
                 ["diameter"] = planet => planet.Diameter,
                 ["surface water"] = planet => planet.Population
             };

        var userChoice = _planetsUserInteractor.
            ChooseStatisticsToBeShown(
                propertyNamesToSelectorsMapping.Keys);

        if (userChoice is null ||
            !propertyNamesToSelectorsMapping.ContainsKey(userChoice))
        {
            _planetsUserInteractor.Show("Invalid choide.");
        }
        else
        {
            ShowStatistics(
                planets,
                userChoice,
                propertyNamesToSelectorsMapping[userChoice]);
        }

    }

    private static void ShowStatistics(
        IEnumerable<Planet> planets,
        string propertyName,
        Func<Planet, int?> propertySelector)
    {
        ShowStatistics(
            "Max",
            planets.MaxBy(propertySelector),
            propertySelector,
            propertyName);

        ShowStatistics(
            "Min",
            planets.MinBy(propertySelector),
            propertySelector,
            propertyName);
    }

    private static void ShowStatistics(
        string descriptor,
        Planet selectedPlanet,
        Func<Planet, int?> propertySelector,
        string propertyName)
    {
        Console.WriteLine($"{descriptor} {propertyName} is: " +
            $"{propertySelector(selectedPlanet)} " +
            $"(planet: {selectedPlanet.Name})");
    }
}
