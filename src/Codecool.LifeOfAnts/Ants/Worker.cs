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
            this.Direction = Extensions.SetRandomDirection();
            this.Position = this.Position.MoveToDirection(this.Direction, this.Colony.Width);
        }
    }
}