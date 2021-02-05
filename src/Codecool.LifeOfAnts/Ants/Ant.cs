namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public Position Position { get; protected internal set; }
        public Direction Direction { get; protected internal set; }
        public Colony Colony { get; protected internal set; }

        public Ant(Position position, Direction direction, Colony colony)
        {
            Position = position;
            Direction = direction;
            Colony = colony;
        }

        public abstract void Move();
    }
}