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
        // TODO
        public Position QueenPosition { get; }
        public Queen Queen { get; }

        private List<Ant> _listOfAnts = new List<Ant>();

        public Colony(int width)
        {
            Width = width;
            QueenPosition = Width.SetQueenPosition();
            Queen = new Queen(QueenPosition, Direction.West, this);
            _listOfAnts.Add(Queen);
        }

        public void GenerateAnts(int amountDrones, int amountSoldiers, int amountWorkers)
        {
            GenerateAntsType<Drone>(amountDrones);
            GenerateAntsType<Soldier>(amountSoldiers);
            GenerateAntsType<Worker>(amountWorkers);

            Extensions.ClearPositionList();
        }

        public void Update()
        {
            foreach (var ant in this._listOfAnts)
            {
                ant.Move();
            }

            ((Queen) Queen).UpdateQueenMatingMood();
        }

        private void GenerateAntsType<T>(int amountAntsOfType)
            where T : Ant
        {
            for (int i = 0; i < amountAntsOfType; i++)
            {
                var parameters = new object[]
                {
                    Width.SetRandomAntPosition(),
                    Extensions.GetRandomDirection(),
                    this,
                };

                var ant = Activator.CreateInstance(typeof(T), parameters) as T;

                _listOfAnts.Add(ant);
            }
        }

        public void Display()
        {
            StringBuilder sb = new StringBuilder();
            string said = string.Empty;
            string row = string.Empty;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (_listOfAnts.Exists(ant => ant.Position.X == i
                                                  && ant.Position.Y == j))
                    {
                        var oneAnt = _listOfAnts.FirstOrDefault(ant => ant.Position.X == i
                                                              && ant.Position.Y == j);
                        if (oneAnt is Worker)
                        {
                            row += $"|W";
                        }
                        else if (oneAnt is Soldier)
                        {
                            row += $"|S";
                        }
                        else if (oneAnt is Drone)
                        {
                            row += $"|D";
                        }
                        else if (oneAnt is Queen)
                        {
                            row += $"|Q";
                        }
                    }
                    else
                    {
                        row += $"| ";
                    }
                }

                said = GetDroneSaid();

                if (i == 0)
                {
                    sb.Append($"{row}|  Queen Mating Mood: {Queen.MatingMood}\n");
                }
                else if (i == 1 && !string.IsNullOrEmpty(said))
                {
                    sb.Append($"{row}|  Drone said: {said}\n");
                }
                else
                {
                    sb.Append($"{row}|\n");
                }

                row = string.Empty;
            }

            ColorAnts(sb);
        }

        private string GetDroneSaid()
        {
            string said = string.Empty;

            foreach (var ant in _listOfAnts)
            {
                if (ant is Drone drone)
                {
                    said = drone.DroneSaid;

                    if (!string.IsNullOrEmpty(said))
                    {
                        break;
                    }
                }
            }

            return said;
        }

        private void ColorAnts(StringBuilder sb)
        {
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
    }
}