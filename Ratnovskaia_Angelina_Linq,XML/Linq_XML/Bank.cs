using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_XML
{
   public class Bank
    {
       public Bank(string name)
       {
           Name = name;
           Clients = new List<Client>();
       }
        public string Name { get; set; }
        public List<Client> Clients { get; set; }

       public override string ToString()
       {
           var result = $"\"{Name}\"\r\n";
           if (Clients != null)
               foreach (var client in Clients )
               {
                   result += client.GetClientInfo() + "\r\n";
               }
           
           return result;
       }
    }
}
