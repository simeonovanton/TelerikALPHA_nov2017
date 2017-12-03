using System;
using System.Text.RegularExpressions;

class ParseURL
{
    static void Main()
    {
        // Regex solution
        //string URL = Console.ReadLine();

        //var fragments = Regex.Match(URL, "(.*)://(.*?)(/.*)").Groups;

        //Console.WriteLine("[protocol] = {0}", fragments[1]);
        //Console.WriteLine("[server] = {0}", fragments[2]);
        //Console.WriteLine("[resource] = {0}", fragments[3]);

        // Non-regex solution
        string line = Console.ReadLine();

        int protocolInd = line.IndexOf("://");
        string protocol = line.Substring(0, protocolInd);

        int serverInd = line.IndexOf("/", protocolInd + 3);
        string server = line.Substring(protocolInd + 3, serverInd - (protocolInd + 3));

        string resource = line.Substring(serverInd);

        string tidied = String.Format("[protocol] = {0}\n[server] = {1}\n[resource] = {2}", protocol, server, resource);
        Console.WriteLine(tidied);
    }
}