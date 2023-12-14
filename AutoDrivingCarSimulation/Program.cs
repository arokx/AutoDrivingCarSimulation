using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Entities.Enums;
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
        try
        {


            var carService = new CarService();
            var simulationService = new SimulationService(carService);

            // Read input
            Console.WriteLine("Enter the width and height of the field");
            string[] fieldSize = Console.ReadLine()?.Split() ?? Array.Empty<string>();
            int width = int.Parse(fieldSize[0]);
            int height = int.Parse(fieldSize[1]);

            Console.WriteLine("Enter the current position and facing direction of the car");
            string[] initialPosition = Console.ReadLine()?.Split() ?? Array.Empty<string>();
            int x = int.Parse(initialPosition[0]);
            int y = int.Parse(initialPosition[1]);
            char direction = char.Parse(initialPosition[2]);

            Console.WriteLine("Enter the commands");
            string commands = Console.ReadLine() ?? string.Empty;


            var finalPosition = simulationService.RunSimulation(width, height, x, y, GetDirection(direction), commands);

            Console.WriteLine($"{finalPosition.X} {finalPosition.Y} {finalPosition.Facing}");
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid Inputs! Please ensure your input follows the correct format:");
            Console.WriteLine("Field: width height (e.g., 10 10)");
            Console.WriteLine("Position: x y direction (e.g., 1 2 N)");
            Console.WriteLine("Commands: a sequence of L, R, and F (e.g., FFRFFFRRLF)");
        }
    }

    public static DomainEnums.Direction GetDirection(char direction)
    {
        switch (direction)
        {
            case 'W':
                return Direction.West;
            case 'S':
                return Direction.South;
            case 'E':
                return Direction.East;
            case 'N':
                return Direction.North;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction));
        }
    }
}