using System.Collections.Generic;

namespace Linq_XML
{
  
   public class Bank
    {
       public Bank(string name)
       {
           Name = name;
           Clients = new List<Client>();
       }

        public Bank()
        {           
        }

        public string Name { get; set; }


        public List<Client> Clients { get; set; }

    }
}
