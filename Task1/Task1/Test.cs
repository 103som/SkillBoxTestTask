using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Простая тестировка кода.
    /// </summary>
    internal class Test
    {
        List<Employer> employers = new List<Employer>();

        public void PrintClients()
        {
            foreach (var client in Bank.getBank().GetClients())
                Console.WriteLine(client.Value.Surname + ' ' + client.Value.Name + ' ' + client.Value.Patronymic +
                                  client.Value.PhoneNumber + ' ' + client.Value.DocumentData);
        }

        public void PrintEmployers()
        {
            foreach (var employer in employers)
                Console.WriteLine(employer);
        }

        public void CreateClients()
        {
            var q = Bank.getBank().GetClients();

            Bank.getBank().AddClient(new Client("Petrov", "Ivan", "Ivanovich", "89220122235", "5019421555", "1"));
            Bank.getBank().AddClient(new Client("Vasiliev", "Andey", "Petrovich", "89220122246", "5019421555", "2"));
            Bank.getBank().AddClient(new Client("Devyterenko", "Dmitry", "Ivanovich", "89220122235", "5019421555", "3"));
            Bank.getBank().AddClient(new Client("Vadimov", "Vano", "Ivanovich", "89220122235", "5019421555", "4"));
            Bank.getBank().AddClient(new Client("Murov", "Alexey", "Ivanovich", "89220122235", "5019421555", "5"));


            ClientDataStorage.SaveClients();
            PrintClients();
        }

        public void CreateEmployers()
        {
            for (int i = 0; i < 5; ++i)
                employers.Add(new Consultant($"Consultant{i}", $"{i}"));

            PrintEmployers();
        }

        public void TestGetPassword(string employerId, string clientId) =>
            Console.WriteLine((new Consultant("1", "1")).GetPassportData(clientId));

        public void TestClientLoad(string clientId)
        {
            var employer = new Consultant("TestConsultant", "001");
            ClientDataStorage.downloadClient(int.Parse(clientId));

            if (employer == null)
                return;

            Console.WriteLine(employer.GetSurname(clientId) + ' ' + employer.GetName(clientId) +
                              employer.GetPatronymic(clientId) + ' ' + employer.GetPassportData(clientId) + ' ' +
                              employer.GetPhoneNumber(clientId));
        }
    }
}
