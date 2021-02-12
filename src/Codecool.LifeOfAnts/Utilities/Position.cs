namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Position struct
    /// </summary>
    public struct Position
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Position"/> struct.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets X coordinate
        /// </summary>
        public int X { get; }

        /// <summary>
        ///     Gets Y coordinate
        /// </summary>
        public int Y { get; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Position position)
            {
                return this.X == position.X && this.Y == position.Y;
            }
            else
            {
                return false;
            }
        }

        public static Position Zero => new Position(0, 0);
    }
}