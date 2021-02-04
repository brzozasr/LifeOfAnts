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
        public int Width { get; }
        private List<Ant> _listOfAnts = new List<Ant>();
        private readonly Position _queenPosition;

        public Colony(int width)
        {
            Width = width;
            _queenPosition = Width.SetQueenPosition();
            Ant queen = new Queen(_queenPosition, Direction.West, this);
            _listOfAnts.Add(queen);
        }

        public void GenerateAnts(int amountDrones, int amountSoldiers, int amountWorkers)
        {
            int[] antsArray = new int[3]
            {
                amountDrones,
                amountSoldiers,
                amountWorkers
            };

            for (int i = 0; i < antsArray.Length; i++)
            {
                for (int j = 0; j < antsArray[i]; j++)
                {
                    if (i == 0)
                    {
                        Ant drone = new Drone(
                            Width.SetRandomAntPosition(),
                            Extensions.SetRandomDirection(),
                            this);
                        _listOfAnts.Add(drone);
                    }
                    else if (i == 1)
                    {
                        Ant soldier = new Soldier(
                            Width.SetRandomAntPosition(),
                            Extensions.SetRandomDirection(),
                            this);
                        _listOfAnts.Add(soldier);
                    }
                    else if (i == 2)
                    {
                        Ant worker = new Worker(
                            Width.SetRandomAntPosition(),
                            Extensions.SetRandomDirection(),
                            this);
                        _listOfAnts.Add(worker);
                    }
                }
            }

            Extensions.ClearPositionList();
        }

        public void Update()
        {
            foreach (var ant in this._listOfAnts)
            {
                ant.Move();
            }
        }

        public void Display()
        {
            StringBuilder sb = new StringBuilder();
            string row = string.Empty;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Width; j++)
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
            Position bottomRight = new Position(Width - 1, Width - 1);

            return position.X >= topLeft.X && position.X <= bottomRight.X &&
                   position.Y >= topLeft.Y && position.Y <= bottomRight.Y;
        }
    }
}