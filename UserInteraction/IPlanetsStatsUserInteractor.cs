public interface IPlanetsStatsUserInteractor
{
    void Show(IEnumerable<Planet> planets);
    string? ChooseStatisticsToBeShown(
        IEnumerable<string> propertiesThaCanBeChosen);
    void ShowMessage(string message);
}
