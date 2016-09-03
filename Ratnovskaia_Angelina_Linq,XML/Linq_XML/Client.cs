using  System.Xml.Serialization;

namespace Linq_XML
{
    public class Client
    {
        public Client(string lastname, string name)
        {
            Lastname = lastname;
            Name = name;
        }

        public Client()
        {
        }

        public string BankName { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Birthday { get; set; }
    }
}
