public class StarWarsPlanetsStatsApp
{
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetsStatisticsAnalyzer _planetsStatisticsAnalyzer;
    private readonly IUserInteractor _userInteractor;

    public StarWarsPlanetsStatsApp(
        IPlanetsReader planetsReader,
        IPlanetsStatisticsAnalyzer planetsStatisticsAnalyzer,
        IUserInteractor userInteractor)
    {
        _planetsReader = planetsReader;
        _planetsStatisticsAnalyzer = planetsStatisticsAnalyzer;
        _userInteractor = userInteractor;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();


        foreach (var planet in planets)
        {
            _userInteractor.ShowMessage(planet.Name);
        }

        _planetsStatisticsAnalyzer.Analyze(planets);
    }

}
