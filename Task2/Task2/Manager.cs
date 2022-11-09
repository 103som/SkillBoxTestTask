using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Manager : Consultant
    {
        public Manager(string name, string id) : base(name, id) { }

        public override string? GetPassportData(string clientId)
        {
            // Если клиента с указанным id не существует, то ничего не делаем.
            var client = Bank.getBank().GetClient(clientId);
            if (client == null || client.DocumentData == null)
                return null;

            return client.DocumentData;
        }

        public void ChangeSurname(string surname, string clientId)
        {
            // Если клиента с указанным id не существует, то ничего не делаем.
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return;

            client.Surname = surname;
        }

        public void ChangeName(string name, string clientId)
        {
            // Если клиента с указанным id не существует, то ничего не делаем.
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return;

            client.Name = name;
        }

        public void ChangePatronymic(string patronymic, string clientId)
        {
            // Если клиента с указанным id не существует, то ничего не делаем.
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return;

            client.Patronymic = patronymic;
        }

        public void ChangePassportData(string passportData, string clientId)
        {
            // Если клиента с указанным id не существует, то ничего не делаем.
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return;

            client.DocumentData = passportData;
        }
    }
}
