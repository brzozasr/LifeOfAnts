using System;
using System.Collections.Generic;

namespace Codecool.LifeOfAnts.ExtensionMethods
{
    public static class Extensions
    {
        private static List<Position> _positions = new List<Position>();

        public static Position SetQueenPosition(this int colonyWidth)
        {
            if (colonyWidth % 2 > 0)
            {
                int pos = colonyWidth / 2;
                var queenPos = new Position(pos, pos);
                _positions.Add(queenPos);
                return queenPos;
            }
            else
            {
                int pos = (colonyWidth / 2) - 1;
                var queenPos = new Position(pos, pos);
                _positions.Add(queenPos);
                return queenPos;
            }
        }

        public static Position SetRandomAntPosition(this int colonyWidth)
        {
            Random random = new Random();
            bool isOnList = true;
            Position antPosition = default;

            while (isOnList)
            {
                int posX = random.Next(0, colonyWidth);
                int posY = random.Next(0, colonyWidth);

                if (!_positions.Exists(pos => pos.X == posX && pos.Y == posY))
                {
                    antPosition = new Position(posX, posY);
                    _positions.Add(antPosition);
                    isOnList = false;
                }
            }

            return antPosition;
        }

        public static Position GetNeighbour(this Position position, Direction direction, int colonyWidth) =>
            direction switch
            {
                Direction.East when position.Y < colonyWidth - 1 => new Position(position.X, position.Y + 1),
                Direction.East => position,
                Direction.West when position.Y > 0 => new Position(position.X, position.Y - 1),
                Direction.West => position,
                Direction.North when position.X > 0 => new Position(position.X - 1, position.Y),
                Direction.North => position,
                Direction.South when position.X < colonyWidth - 1 => new Position(position.X + 1, position.Y),
                Direction.South => position,
                _ => position
            };

        public static int SetQueenMatingMood(this int maxMatingMood)
        {
            Random random = new Random();
            return random.Next(50, maxMatingMood);
        }

        public static Direction GetRandomDirection()
        {
            Random random = new Random();
            Direction randomDirection = (Direction) random.Next(0, 4);
            return randomDirection;
        }

        public static void ClearPositionList()
        {
            _positions.Clear();
        }
    }
}