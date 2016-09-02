﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Linq_XML
{
    internal class Helper
    {

        internal static void Parse(string path, ref List<Bank> banks, ref List<Client> clients)
        {
            var text = System.IO.File.ReadAllText(path);
            const string pattern1 = @"Банк: ";
            const string pattern2 = @"Клиент: ";


            var elements = Regex.Split(text, pattern1).ToList();

            elements.RemoveAll(element => element == "");

            foreach (var element in elements)
            {
                var items = Regex.Split(element, pattern2);

                for (var i = 0; i < items.Length; i++)
                {
                    items[i] = items[i].Trim();
                }

                var bank = new Bank(items[0]);

                banks.Add(bank);

                for (var i = 1; i < items.Length; i++)
                {

                    var attributes = items[i].Split(',');
                    var fullName = attributes[0].Split(' ');
                    var client = new Client(fullName[0].Trim(), fullName[1].Trim()) { Bank = bank, Birthday = attributes[1].Trim() };
                    if (fullName.Length >= 3) client.Middlename = fullName[2];
                    bank.Clients.Add(client);
                    clients.Add(client);

                }
            }

        }

        internal static IEnumerable<object> Search(string str, List<Bank> banks, List<Client> clients)
        {
            if (str == null) return null;
            var filter = str.ToLower();
            var queryClients =
                from cl in clients
                where (cl.Lastname.ToLower().Contains(filter) || cl.Name.ToLower().Contains(filter) || (cl.Middlename != null && cl.Middlename.ToLower().Contains(filter)))
                select cl;

            var enumerable = queryClients as IList<Client> ?? queryClients.ToList();
            if (enumerable.Any()) return enumerable;
            var queryBanks =
                from bank in banks
                where (bank.Name.ToLower().Contains(filter))
                select bank;
            return queryBanks;
        }
    }
}