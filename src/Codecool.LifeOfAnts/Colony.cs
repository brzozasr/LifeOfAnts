using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.LifeOfAnts.Ants;
using Codecool.LifeOfAnts.ExtensionMethods;

namespace Codecool.LifeOfAnts
{
    public class Colony
    {
        private readonly int _width;
        private List<Ant> _listOfAnts = new List<Ant>();

        public Colony(int width)
        {
            _width = width;
            Ant queen = new Queen(_width.GetQueenPosition(), Direction.West, this);
            _listOfAnts.Add(queen);
        }

        public void GenerateAnts(int amountWorkers, int amountSoldiers, int amountDrones)
        {
            int[] antsArray = new int[3]
            {
                amountWorkers,
                amountSoldiers,
                amountDrones
            };

            for (int i = 0; i < antsArray.Length; i++)
            {
                for (int j = 0; j < antsArray[i]; j++)
                {
                    if (i == 0)
                    {
                        Ant worker = new Worker(
                            _width.GetRandomAntPosition(),
                            Extensions.GetRandomDirection(),
                            this);
                        _listOfAnts.Add(worker);
                    }
                    else if (i == 1)
                    {
                        Ant soldier = new Soldier(
                            _width.GetRandomAntPosition(),
                            Extensions.GetRandomDirection(),
                            this);
                        _listOfAnts.Add(soldier);
                    }
                    else if (i == 2)
                    {
                        Ant drone = new Drone(
                            _width.GetRandomAntPosition(),
                            Extensions.GetRandomDirection(),
                            this);
                        _listOfAnts.Add(drone);
                    }
                }
            }
            
            Extensions.ClearPositionList();
        }

        public void Update()
        {
        }

        public void Display()
        {
            StringBuilder sb = new StringBuilder();
            string row = string.Empty;

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (_listOfAnts.Exists(ant => ant.Position.X == i
                                                  && ant.Position.Y == j))
                    {
                        var oneAnt = _listOfAnts.Where(ant => ant.Position.X == i
                                                              && ant.Position.Y == j).ToList();
                        if (oneAnt.ElementAt(0).GetType().Name == "Worker")
                        {
                            row += $"|W";
                        }
                        else if (oneAnt.ElementAt(0).GetType().Name == "Soldier")
                        {
                            row += $"|S";
                        }
                        else if (oneAnt.ElementAt(0).GetType().Name == "Drone")
                        {
                            row += $"|D";
                        }
                        else if (oneAnt.ElementAt(0).GetType().Name == "Queen")
                        {
                            row += $"|Q";
                        }
                    }
                    else
                    {
                        row += $"| ";
                    }
                }

                sb.Append($"{row}|\n");
                row = string.Empty;
            }

            foreach (var charSb in sb.ToString())
            {
                if (charSb == 'W')
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(charSb);
                    Console.ResetColor();
                }
                else if (charSb == 'S')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(charSb);
                    Console.ResetColor();
                }
                else if (charSb == 'D')
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(charSb);
                    Console.ResetColor();
                }
                else if (charSb == 'Q')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(charSb);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(charSb);
                }
            }
        }

        public bool ValidPosition(Position position)
        {
            Position topLeft = new Position(0, 0);
            Position bottomRight = new Position(_width - 1, _width - 1);

            return position.X >= topLeft.X && position.X <= bottomRight.X &&
                   position.Y >= topLeft.Y && position.Y <= bottomRight.Y;
        }
    }
}