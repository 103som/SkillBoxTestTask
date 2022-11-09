using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace Task2
{
    /// <summary>
    /// Класс банка, здесь используется паттерн Singleton, т.к. банк только один.
    /// </summary>
    internal class Bank
    {
        private static Bank bank;

        /// <summary>
        /// Список всех клиентов, получение клиента по его id.
        /// </summary>
        private Dictionary<string, Client> clients = new Dictionary<string, Client>();

        private Bank() { }

        public static Bank getBank()
        {
            if (bank == null)
            {
                bank = new Bank();

                ClientDataStorage.AutoLoadClients();
            }

            return bank;
        }

        /// <summary>
        /// Добавление нового клиента.
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            if (clients.ContainsKey(client.Id))
                return;

            clients.Add(client.Id, client);
        }

        /// <summary>
        /// Получение клиента по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client? GetClient(string id)
        {
            if (!clients.ContainsKey(id))
                return null;

            return clients[id];
        }

        /// <summary>
        /// Получение списка всех клиентов.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Client> GetClients() => clients;
    }
}