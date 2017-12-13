using System;

public class GSMTest

{
	public GSMTest()
	{

        //public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display) 
        GSM[] mobilePhones = new GSM[3]
            {
                {"HelloMotto", "Motorolla", 100m, "Boko Tikvata!", new Battery(BatteryType.LiIon, 100, 10),  new Display{5, 256}},
                {"P10Lite", "Huawei", 195m, "Boko Sexo!", new Battery( BatteryType.LiPolymer, 200, 20),  new Display{7, 512} },
                {"Galaxy S 10", "Samsung", 300m, "Cecko Sexo!", new Battery( BatteryType.NiMH, 300, 30),  new Display{10, 1024}}
            };

        foreach (var phone in mobilePhones)
        {
            Console.WriteLine(phone.ToString());
        }
        Console.WriteLine(GSM.ToString());
	}
}
