namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }
        public Colony Colony { get; private set; }

        public Ant(Position position, Direction direction, Colony colony)
        {
            Position = position;
            Direction = direction;
            Colony = colony;
        }

        public abstract void Move();
    }
}