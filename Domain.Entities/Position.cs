using static Domain.Entities.Enums.DomainEnums;

namespace Domain.Entities
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }
        public Direction Facing { get; }

        public Position(int x, int y, Direction facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }
    }
}