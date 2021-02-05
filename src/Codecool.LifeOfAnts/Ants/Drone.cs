using Codecool.LifeOfAnts.ExtensionMethods;

namespace Codecool.LifeOfAnts.Ants
{
    public class Drone : Ant
    {
        public Drone(Position position, Direction direction, Colony colony) : base(position, direction, colony)
        {
        }

        public override void Move()
        {
            SetDroneDirection();

            if (!this.IsDroneReachedStopPosition(Position))
            {
                Position = Position.MoveToDirection(Direction, Colony.Width);
            }
        }

        private void SetDroneDirection()
        {
            Position queenPosition = Colony.QueenPosition;

            if (queenPosition.X > Position.X)
            {
                Direction = Direction.South;
            }
            else if (queenPosition.Y > Position.Y)
            {
                Direction = Direction.East;
            }
            else if (queenPosition.X < Position.X)
            {
                Direction = Direction.North;
            }
            else if (queenPosition.Y < Position.Y)
            {
                Direction = Direction.West;
            }
        }

        private bool IsDroneReachedStopPosition(Position dronePosition)
        {
            Position queenPosition = Colony.QueenPosition;
            Position westStopPosition = new Position(queenPosition.X, queenPosition.Y - 1);
            Position eastStopPosition = new Position(queenPosition.X, queenPosition.Y + 1);
            Position northStopPosition = new Position(queenPosition.X - 1, queenPosition.Y);
            Position southStopPosition = new Position(queenPosition.X + 1, queenPosition.Y);

            if ((dronePosition.X == westStopPosition.X && dronePosition.Y == westStopPosition.Y) ||
                (dronePosition.X == eastStopPosition.X && dronePosition.Y == eastStopPosition.Y) ||
                (dronePosition.X == northStopPosition.X && dronePosition.Y == northStopPosition.Y) ||
                (dronePosition.X == southStopPosition.X && dronePosition.Y == southStopPosition.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}