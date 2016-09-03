using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using  System.Xml.Serialization;

namespace Linq_XML
{
    internal class Program
    {
        static void Main()
        {
            var banks = new List<Bank>();
            var clients = new List<Client>();

            Helper.Parse(@"input.txt", ref banks, ref clients);

            Console.WriteLine("Введите строку для поиска:");

            var str = Console.ReadLine();

            var stream = new FileStream("serialization.xml", FileMode.Create, FileAccess.ReadWrite);         
            var result = Helper.ClientSearch(str, clients);

            if (result.Any())
            {
                var clientSerializer = new XmlSerializer(typeof(List<Client>));
                clientSerializer.Serialize(stream, result);
            }

        else
            {
                var bankSerializer = new XmlSerializer(typeof(List<Bank>));
                bankSerializer.Serialize(stream, Helper.BankSearch(str, banks));
            }   

        }
    }
}
