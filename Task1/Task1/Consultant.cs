using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    internal class Consultant : Employer
    {
        [JsonConstructor]
        public Consultant(string name, string id) : base(name, id) { }

        public override string? GetPassportData(string clientId)
        {
            var client = Bank.getBank().GetClient(clientId);
            if (client == null || client.DocumentData == null)
                return null;

            return ("******************");
        }
    }
}
