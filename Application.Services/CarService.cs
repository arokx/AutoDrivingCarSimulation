using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Enums;
using static Domain.Entities.Enums.DomainEnums;

namespace Application.Services
{
    public class CarService : ICarService
    {
        public Position MoveForward(Position currentPosition, int width, int height)
        {
            int newX = currentPosition.X;
            int newY = currentPosition.Y;

            switch (currentPosition.Facing)
            {
                case Direction.North:
                    newY++;
                    break;
                case Direction.East:
                    newX++;
                    break;
                case Direction.South:
                    newY--;
                    break;
                case Direction.West:
                    newX--;
                    break;
            }

            if (IsValidPosition(newX, newY, width, height))
            {
                return new Position(newX, newY, currentPosition.Facing);
            }

            return currentPosition; 
        }

        public DomainEnums.Direction RotateLeft(DomainEnums.Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    return Direction.West;
                case Direction.West:
                    return Direction.South;
                case Direction.South:
                    return Direction.East;
                case Direction.East:
                    return Direction.North;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentDirection));
            }
        }

        public DomainEnums.Direction RotateRight(DomainEnums.Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    return Direction.East;
                case Direction.West:
                    return Direction.North;
                case Direction.South:
                    return Direction.West;
                case Direction.East:
                    return Direction.South;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentDirection));
            }
        }

        private bool IsValidPosition(int x, int y, int fieldWidth, int fieldHeight)
        {
            return x >= 0 && x < fieldWidth && y >= 0 && y < fieldHeight;// car should move in the given field.
        }
    }
}