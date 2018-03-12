using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Practice
{
    class XML_Pract
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            //doc.Load("../../../../shiporders.xml");
            doc.Load(@"D:\TelerikAcademy\TelerikALPHA_nov2017\08.DataBases\XML&JSON/shiporders.xml");

            var rootNode = doc.DocumentElement;
            // Console.WriteLine(docAtrs);

            foreach (XmlAttribute attr in rootNode.Attributes)
            {
                Console.WriteLine(attr.Name);
            }
            Console.WriteLine();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == "item")
                {
                    foreach (XmlNode chilnode in node.ChildNodes)
                    {
                        Console.WriteLine($"{chilnode.Name}: {chilnode.InnerText}");
                    }
                    Console.WriteLine();

                }
            }

        }
    }
}
