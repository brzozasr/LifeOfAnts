namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public Position Position { get; protected set; }
        public Direction Direction { get; protected set; }
        public Colony Colony { get; }

        public Ant(Position position, Direction direction, Colony colony)
        {
            Position = position;
            Direction = direction;
            Colony = colony;
        }

        public abstract void Move();
    }
}