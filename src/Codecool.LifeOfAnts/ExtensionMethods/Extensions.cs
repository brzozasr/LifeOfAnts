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
        
        public static Position MoveToDirection(this Position position,  Direction direction, int colonyWidth)
        {
            if (direction == Direction.East)
            {
                if (position.Y < colonyWidth - 1)
                {
                    return new Position(position.X, position.Y + 1);
                }
                else
                {
                    return position;
                }
            }
            else if (direction == Direction.West)
            {
                if (position.Y > 0)
                {
                    return new Position(position.X, position.Y - 1);
                }
                else
                {
                    return position;
                }
            }
            else if (direction == Direction.North)
            {
                if (position.X > 0)
                {
                    return new Position(position.X - 1, position.Y);
                }
                else
                {
                    return position;
                }
            }
            else if (direction == Direction.South)
            {
                if (position.X < colonyWidth - 1)
                {
                    return new Position(position.X + 1, position.Y);
                }
                else
                {
                    return position;
                }
            }
            else
            {
                return position;
            }
        }

        public static Direction SetRandomDirection()
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