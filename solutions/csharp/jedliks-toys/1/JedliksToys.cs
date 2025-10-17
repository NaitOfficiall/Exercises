class RemoteControlCar
{
    public int distance = 0;
    public int battery = 100;
    
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {distance} meters";

    public string BatteryDisplay() => battery > 0 ? $"Battery at {battery}%" : "Battery empty";

    public void Drive()
    {
        if(this.battery > 0)
        {
            this.distance += 20;
            this.battery -= 1;
        }
    }
}
