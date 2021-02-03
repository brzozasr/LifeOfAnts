namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        internal Position Position;
        internal Direction Direction;
        internal Colony Colony;

        public Ant(Position position, Direction direction, Colony colony)
        {
            Position = position;
            Direction = direction;
            Colony = colony;
        }

        public abstract void Move();
    }
}