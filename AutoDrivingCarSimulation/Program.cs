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
        var program = new Program(carService);
        program.RunSimulation(10, 10, 1, 2, Direction.North, "FFRFFFRRLF");
    }

    public void RunSimulation(int fieldWidth, int fieldHeight, int initialX, int initialY, Direction initialFacing, string commands)
    {
        var currentPosition = new Position(initialX, initialY, initialFacing);

        foreach (var command in commands)
        {
            switch (command)
            {
                case 'F':
                    currentPosition = _carService.MoveForward(currentPosition, fieldWidth, fieldHeight);
                    break;
                case 'L':
                    currentPosition = new Position(currentPosition.X, currentPosition.Y, _carService.RotateLeft(currentPosition.Facing));
                    break;
                case 'R':
                    currentPosition = new Position(currentPosition.X, currentPosition.Y, _carService.RotateRight(currentPosition.Facing));
                    break;
                    // Handle other commands if needed
                    // ...
            }
        }

        Console.WriteLine($"{currentPosition.X} {currentPosition.Y} {currentPosition.Facing}");
    }
}