class RemoteControlCar
{
    private int speed;
    private int batteryDrain;
    private int distanceDriven;
    private int battaryCharge;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        distanceDriven = 0;
        battaryCharge = 100;
    }

    public bool BatteryDrained() => battaryCharge < batteryDrain;

    public int DistanceDriven() => distanceDriven;

    public void Drive()
    {
        if(!BatteryDrained() && battaryCharge >= batteryDrain)
            distanceDriven = distanceDriven + speed;
        battaryCharge = battaryCharge - batteryDrain;
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50,4);
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }
        
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while(!car.BatteryDrained())
        {
            car.Drive();
        }
        return car.DistanceDriven() >= distance;
    }
}