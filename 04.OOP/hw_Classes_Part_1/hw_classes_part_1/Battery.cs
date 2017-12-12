using System;

public class Battery
{

	public Battery(BatteryType model, int hoursIdle, int hoursTalk)
	{
        this.Model = model;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
	}

    public BatteryType Model { get; set; }
    public int HoursIdle { get; set; }
    public int HoursTalk { get; set; }

    public override string ToString()
    {
        return $"Battery model: {Model} {Environment.NewLine} HoursIdle: {HoursIdle}" +
                 $"{Environment.NewLine} HoursTalk:{HoursTalk} ";
    }
}
