using Codecool.LifeOfAnts.ExtensionMethods;

namespace Codecool.LifeOfAnts.Ants
{
    public class Queen : Ant
    {
        public int MatingMood { get; protected internal set; }
        public Queen(Position position, Direction direction, Colony colony) : base(position, direction, colony)
        {
            int maxMatingMood = 101;
            MatingMood = maxMatingMood.SetQueenMatingMood();
        }

        public override void Move()
        {
        }

        public void UpdateQueenMatingMood()
        {
            if (MatingMood > 0)
            {
                MatingMood--;
            }
        }
    }
}