using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Manager : Consultant
    {
        public Manager(string name, string id) : base(name, id) { }

        public new void ChangedData(string changedType, string clientId)
        {
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return;

            client.TimeDataChanged = Bank.stopWatch.ToString();
            client.LastChangedData = changedType;
            client.IsConsultantChanged = false;
        }

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
            ChangedData("Surname", clientId);
        }

        public void ChangeName(string name, string clientId)
        {
            // Если клиента с указанным id не существует, то ничего не делаем.
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return;

            client.Name = name;
            ChangedData("Name", clientId);
        }

        public void ChangePatronymic(string patronymic, string clientId)
        {
            // Если клиента с указанным id не существует, то ничего не делаем.
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return;

            client.Patronymic = patronymic;
            ChangedData("Patronymic", clientId);
        }

        public void ChangePassportData(string passportData, string clientId)
        {
            // Если клиента с указанным id не существует, то ничего не делаем.
            var client = Bank.getBank().GetClient(clientId);
            if (client == null)
                return;

            client.DocumentData = passportData;
            ChangedData("PassportData", clientId);
        }
    }
}