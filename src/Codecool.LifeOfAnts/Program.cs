using System;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Simulation main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            int colonyWidth = 5;
            var ants = Utilis.SetNumberOfAnts(colonyWidth);

            Colony colony = new Colony(colonyWidth);
            colony.GenerateAnts(ants.amountDrones, ants.amountSoldiers, ants.amountWorkers);
            Console.Clear();
            colony.Display();

            bool isRunning = true;

            while (isRunning)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    colony.Update();
                    Console.Clear();
                    colony.Display();
                }
                else if (keyInfo.Modifiers == ConsoleModifiers.Control && keyInfo.Key == ConsoleKey.Q)
                {
                    isRunning = false;
                }
                else
                {
                    Console.Clear();
                    colony.Display();
                }
            }
        }
    }
}