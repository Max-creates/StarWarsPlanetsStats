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
             new Dictionary<string, Func<Planet, long?>>()
             {
                 ["population"] = planet => planet.Population,
                 ["diameter"] = planet => planet.Diameter,
                 ["surface water"] = planet => planet.Population
             };
        _planetsUserInteractor.Show(planets);

        var userChoice = _planetsUserInteractor.
            ChooseStatisticsToBeShown(
                propertyNamesToSelectorsMapping.Keys);

        if (userChoice is null ||
            !propertyNamesToSelectorsMapping.ContainsKey(userChoice))
        {
            _planetsUserInteractor.ShowMessage("Invalid choide.");
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
        Func<Planet, long?> propertySelector)
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
        Func<Planet, long?> propertySelector,
        string propertyName)
    {
        Console.WriteLine($"{descriptor} {propertyName} is: " +
            $"{propertySelector(selectedPlanet)} " +
            $"(planet: {selectedPlanet.Name})");
    }
}
