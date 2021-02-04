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
            int colonyWidth = 21;
            var ants = Utilis.GetNumberOfAnts(colonyWidth);

            Colony colony = new Colony(colonyWidth);
            colony.GenerateAnts(ants.amountWorkers, ants.amountSoldiers, ants.amountDrones);

            colony.Display();
        }
    }
}