using System;
using System.Collections.Generic;

namespace Codecool.LifeOfAnts.ExtensionMethods
{
    public static class Extensions
    {
        private static List<Position> _positions = new List<Position>();

        public static Position GetQueenPosition(this int colonyWidth)
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

        public static Position GetRandomAntPosition(this int colonyWidth)
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
        
        public static Position MoveDirection(this Direction direction, Position position)
        {
            if (direction == Direction.East)
            {
                
            }
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