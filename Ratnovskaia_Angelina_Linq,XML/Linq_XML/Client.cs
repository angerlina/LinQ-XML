using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_XML
{
   public class Client
    {
       public Client(string lastname, string name)
       {
           Lastname = lastname;
           Name = name;

       }
        public  string Name { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }

        public string Birthday { get; set; }

        public Bank Bank { get; set; }
        public override string ToString()
        {
            return $"{Lastname} {Name} {Middlename}, {Birthday}, {Bank.Name}";
        }

       public string GetClientInfo()
       {
            return $"{Lastname} {Name} {Middlename}, {Birthday}";
        }
    }
}
