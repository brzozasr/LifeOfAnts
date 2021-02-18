using Codecool.LifeOfAnts.ExtensionMethods;

namespace Codecool.LifeOfAnts.Ants
{
    public class Worker : Ant
    {
        public Worker(Position position, Direction direction, Colony colony) : base(position, direction, colony)
        {
        }

        public override void Move()
        {
            this.Direction = Extensions.GetRandomDirection();
            this.Position = this.Position.GetNeighbour(this.Direction, this.Colony.Width);
        }
    }
}