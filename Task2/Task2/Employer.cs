using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Абстрактный класс сотрудника компании.
    /// </summary>
    public abstract class Employer
    {
        /// <summary>
        /// Имя работника.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Доп. свойство для сохранения каждого отдельного человека в виде 'id.json'.
        /// </summary>
        public string Id { get; set; }

        public Employer(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public abstract string? GetPassportData(string clientId);

        public string? GetName(string clientId)
        {
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return null;

            return client.Name;
        }
        public string? GetSurname(string clientId)
        {
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return null;

            return client.Surname;
        }
        public string? GetPatronymic(string clientId)
        {
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return null;

            return client.Patronymic;
        }
        public string? GetPhoneNumber(string clientId)
        {
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return null;

            return client.PhoneNumber;
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

        public override string ToString()
        {
            return ($"Name:{Name}; Id:{Id}");
        }
    }
}