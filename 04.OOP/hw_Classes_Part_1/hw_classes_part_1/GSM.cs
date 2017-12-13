using System;

public class GSM
{

    private string model;
    private string manufacturer;
    private decimal price;
    private string owner;
    private Battery battery;
    private Display display;

    public GSM(string model, string manufacturer):this(model,  manufacturer, 0,  null,  null,  null)
    {
        
    }

   
    public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display) 
    {
        if (string.IsNullOrEmpty(model))
        {
            throw new ArgumentNullException(nameof(model), "Model can't be null or blank!");
        }
        this.Model = model;
        if (string.IsNullOrEmpty(manufacturer))
        {
            throw new ArgumentNullException(nameof(manufacturer), "Manufacturer can't be null or blank!");
        }
        this.Manufacturer = manufacturer;
    }

    public static GSM IPhone4S => new GSM("4S", "HUawei", 10m, "Yaze'ka!", new Battery(BatteryType.LiIon, 100, 5), new Display(5, 200));

    public List<Call> CallHistory { get; set; }

    public void CallAdd(Call call)
    {
        CallHistory.Add(call);
    }

    public void CallRemove(Call call)
    {
        CallHistory.Remove(call);
    }

    public void CallClear(Call call)
    {
        CallHistory.Clear(call);
    }

    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public decimal Price { get; set; }
    public string Owner { get; set; }
    public Battery Battery { get; set; }
    public Display Display { get; set; }

    public override string ToString()
    {
        return $"{this.Model}, {this.Manufacturer}, {this.Price}, {this.Owner}, {this.Battery.ToString()}, {this.Display.ToString()}";
    }
}
