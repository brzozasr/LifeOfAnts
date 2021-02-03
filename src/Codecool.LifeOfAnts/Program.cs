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
            Colony colony = new Colony(21);
            colony.GenerateAnts(100, 50, 5);
            
            colony.Display();
        }
    }
}
