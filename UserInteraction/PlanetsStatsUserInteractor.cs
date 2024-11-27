public class PlanetsStatsUserInteractor : IPlanetsStatsUserInteractor
{
    private readonly IUserInteractor _userInteractor;

    public PlanetsStatsUserInteractor(
        IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public string? ChooseStatisticsToBeShown(IEnumerable<string> propertiesThaCanBeChosen)
    {
        _userInteractor.ShowMessage(Environment.NewLine);
        _userInteractor.ShowMessage(
            "The statistics of which property would you " +
            "like to see?");
        _userInteractor.ShowMessage(
            string.Join(
                Environment.NewLine, 
                propertiesThaCanBeChosen));

        return _userInteractor.ReadFromUser();
    }

    public void Show(string message)
    {
        _userInteractor.ShowMessage(message);
    }

}
