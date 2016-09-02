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
            var result = Helper.Search(str, banks, clients);

            var bankList = new List<Bank>();
            var clientList = new List<Client>();

           
            foreach (var element in result)
            {
                var temp1 = element as Client;
                var temp2 = element as Bank;

                if (temp1 != null)
                {
                    clientList.Add(temp1);
                }

                if (temp2 != null)
                {
                    bankList.Add(temp2);
                }
            }

            File.Delete("serialization.xml");
            var stream = new FileStream("serialization.xml", FileMode.Append);

            var clientSerializer = new XmlSerializer(typeof(List<Client>));
            var bankSerializer = new XmlSerializer(typeof(List<Bank>));

            clientSerializer.Serialize(stream, clientList);
            bankSerializer.Serialize(stream, bankList);

        }
    }
}
