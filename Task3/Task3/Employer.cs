using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Task3
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

        public override string ToString()
        {
            return ($"Name:{Name}; Id:{Id}");
        }
    }
}