namespace Codecool.LifeOfAnts
{
    public static class Utilis
    {
        public static (int amountWorkers, int amountSoldiers, int amountDrones) GetNumberOfAnts(int colonyWidth)
        {
            int colonySize = colonyWidth * colonyWidth;
            float percentageOfSettlement = 0.45f;
            int amountOfAnts = (int) (colonySize * percentageOfSettlement);

            int workers = (int) (amountOfAnts * 0.6f);
            int soldiers = (int) (amountOfAnts * 0.35f);
            int drones = (int) (amountOfAnts * 0.05f);

            if (drones < 0)
            {
                drones = 1;
            }

            return (workers, soldiers, drones);
        }
    }
}