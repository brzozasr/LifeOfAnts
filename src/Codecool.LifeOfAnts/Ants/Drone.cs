using System;
using System.Collections.Generic;
using Codecool.LifeOfAnts.ExtensionMethods;

namespace Codecool.LifeOfAnts.Ants
{
    public class Drone : Ant
    {
        public string DroneSaid { get; private set; }

        private int _counter = 0;
        private bool _isMatingSuccessfully = false;

        public Drone(Position position, Direction direction, Colony colony) : base(position, direction, colony)
        {
        }

        public override void Move()
        {
            DroneSaid = string.Empty;

            if (!_isMatingSuccessfully)
            {
                SetDroneDirection();

                if (!this.IsDroneReachedStopPosition(Position))
                {
                    Position = Position.MoveToDirection(Direction, Colony.Width);
                }

                if (this.IsDroneReachedStopPosition(Position) && Colony.Queen.MatingMood > 0)
                {
                    RandomBorderPosition();
                    DroneSaid = ":(";
                }
                else if (this.IsDroneReachedStopPosition(Position) && Colony.Queen.MatingMood == 0)
                {
                    int maxMatingMood = 101;
                    Colony.Queen.MatingMood = maxMatingMood.SetQueenMatingMood();
                    _isMatingSuccessfully = true;
                    DroneSaid = "HALLELUJAH!";
                }
            }
            else
            {
                if (_counter == 9)
                {
                    _isMatingSuccessfully = false;
                    _counter = 0;
                }

                _counter++;
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

        private void RandomBorderPosition()
        {
            Random random = new Random();

            Position topBorder = new Position(0, random.Next(0, Colony.Width));
            Position rightBorder = new Position(random.Next(0, Colony.Width), Colony.Width - 1);
            Position bottomBorder = new Position(Colony.Width - 1, random.Next(0, Colony.Width));
            Position leftBorder = new Position(random.Next(0, Colony.Width), 0);

            List<Position> randomBorderPosition = new List<Position>()
            {
                topBorder,
                rightBorder,
                bottomBorder,
                leftBorder
            };

            int randomIndex = random.Next(0, 4);

            Position = randomBorderPosition[randomIndex];
        }
    }
}