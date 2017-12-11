using System;

public class Battery
{
    private string model;
    private int hoursIdle;
    private int hoursTalk;

	public Battery(string model, int hoursIdle, int hoursTalk)
	{
        this.Model = model;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
	}

    public string Model { get; set; }
    public int HoursIdle { get; set; }
    public int HoursTalk { get; set; }


}
