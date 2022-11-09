using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task3
{
    public class Consultant : Employer, IChangedData
    {
        public Consultant(string name, string id) : base(name, id) { }

        public void ChangedData(string changedType, string clientId)
        {
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return;

            client.TimeDataChanged = Bank.stopWatch.ToString();
            client.LastChangedData = changedType;
            client.IsConsultantChanged = true;
        }

        public void ChangePhoneNumber(string clientId, string phoneNumber)
        {
            if (Bank.getBank().GetClient(clientId) == null)
                throw new ArgumentException("Wrong client Id!");

            if (phoneNumber.Length > 12 || phoneNumber.Length < 11 ||
                (phoneNumber.Length == 12 && (phoneNumber[0] != '+' || phoneNumber[1] != '7')) ||
                (phoneNumber.Length == 11 && phoneNumber[0] != '8'))
                throw new ArgumentException("Wrong number Format!");

            for (int i = 1; i < phoneNumber.Length; ++i)
            {
                if (phoneNumber[i] < '0' || phoneNumber[i] > '9')
                    throw new ArgumentException("Wrong number Format!");
            }

            Bank.getBank().GetClient(clientId).PhoneNumber = phoneNumber;
        }

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