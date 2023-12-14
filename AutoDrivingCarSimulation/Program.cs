using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using static Domain.Entities.Enums.DomainEnums;

public class Program
{
    private readonly ICarService _carService;

    public Program(ICarService carService)
    {
        _carService = carService;
    }
    static void Main(string[] args)
    {
        var carService = new CarService();
        var simulationService = new SimulationService(carService);


        var finalPosition = simulationService.RunSimulation(10, 10, 1, 2, Direction.North, "FFRFFFRRLFLF");

        Console.WriteLine($"{finalPosition.X} {finalPosition.Y} {finalPosition.Facing}");
    }
}