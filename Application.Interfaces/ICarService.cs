using Domain.Entities;
using static Domain.Entities.Enums.DomainEnums;

namespace Application.Interfaces
{
    public interface ICarService
    {
        Position MoveForward(Position currentPosition, int width, int height);
        Direction RotateLeft(Direction currentDirection);
        Direction RotateRight(Direction currentDirection);
    }
}