﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Linq_XML
{
    class Program
    {
        static IEnumerable<object> Search(string s, List<Bank> banks, List<Client> clients)
        {
            if (s != null)
            {
               

                var clientLastnameQuery =
                     from cl in clients
                     where (cl.Lastname.Contains(s))
                     select cl;
                if (clientLastnameQuery.Any()) return clientLastnameQuery;
               
                {
                    var clientNameQuery =
                     from cl in clients
                     where (cl.Name.Contains(s))
                     select cl;
                    if (clientNameQuery.Any()) return clientNameQuery;

                       
                    {
                        var clientMiddlenameQuery =
                     from cl in clients
                     where (cl.Middlename!=null&&cl.Middlename.Contains(s))
                     select cl;

                        if (clientMiddlenameQuery.Any()) return clientMiddlenameQuery;
                        {
                            var bankQuery =
                                from bank in banks
                                where (bank.Name.Contains(s))
                                select bank;
                            return bankQuery;
                        }
                    }
                }

            }
            return null;


        } 
        static void Main()
        {
            string text = System.IO.File.ReadAllText(@"D:\input.txt");
            var pattern1 = @"Банк: ";
            var pattern2 = @"Клиент: ";


            List<string> elements = Regex.Split(text, pattern1).ToList();
            elements.RemoveAll(element => element == "");

            var banks = new List<Bank>();
            var clients = new List<Client>();

            foreach (var element in elements)
            {
               var items = Regex.Split(element, pattern2);

                foreach (var item in items)
                    items[Array.IndexOf(items, item)] = item.Trim();

                var bank = new Bank(items[0]);
                banks.Add(bank);
                for (var i = 1; i < items.Length; i++)
                {

                    string[] attributes = items[i].Split(',');
                    string[] fullName = attributes[0].Split(' ');
                    var client = new Client(fullName[0].Trim(), fullName[1].Trim()) { Bank = bank, Birthday = attributes[1].Trim()};
                    if (fullName.Length >= 3) client.Middlename = fullName[2];
                    bank.Clients.Add(client);
                    clients.Add(client);

                }
            }

            var s = Console.ReadLine().Trim();
            var result = Search(s, banks, clients);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }




            Console.ReadLine();

        }
    }
}