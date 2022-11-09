using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task2
{
    public class Consultant : Employer
    {
        public Consultant(string name, string id) : base(name, id) { }

        public override string? GetPassportData(string clientId)
        {
            // Если клиента с указанным id не существует, то ничего не делаем.
            var client = Bank.getBank().GetClient(clientId);
            if (client == null || client.DocumentData == null)
                return null;

            return ("******************");
        }
    }
}