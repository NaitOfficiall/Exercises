class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new[] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return birdsPerDay.Last();
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        if (birdsPerDay.Contains(0))
        {
            return true;
        } else 
            return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int birdCount = 0;
        for(int i = 0; i < numberOfDays; i++)
        {
            birdCount = birdCount + birdsPerDay[i];
        }
        return birdCount;
    }

    public int BusyDays()
    {
       int busyDayCount = 0;
        foreach (int birds in birdsPerDay)
        {
            if (birds > 4)
                busyDayCount++;
            else
                busyDayCount = busyDayCount + 0;
        }
        return busyDayCount;
    }
}
