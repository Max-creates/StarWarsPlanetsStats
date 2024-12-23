﻿using StarWarsPlanetsStats.ApiDataAccess;

try
{
    var consoleUserInteractor = new ConsoleUserInteractor();
    var planetsStatsUserInteractor =
        new PlanetsStatsUserInteractor(
            consoleUserInteractor);

    await new StarWarsPlanetsStatsApp(
        new PlanetsFromApiReader(
            new ApiDataReader(),
            new MockStarWarsApiDataReader(),
            consoleUserInteractor),
        new PlanetsStatisticsAnalyzer(
            planetsStatsUserInteractor),
        consoleUserInteractor).Run();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred. " +
        "Exception message: " + ex.Message);
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();