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
        // TODO
    }


}
