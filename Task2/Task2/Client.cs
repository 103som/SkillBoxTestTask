using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task2
{
    [Serializable]
    internal class Client
    {
        [JsonPropertyName("Фамилия")]
        public string Surname { get; set; }

        [JsonPropertyName("Имя")]
        public string Name { get; set; }

        [JsonPropertyName("Отчество")]
        public string Patronymic { get; set; }

        [JsonPropertyName("Номер телефона")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("Паспортные данные")]
        public string? DocumentData { get; set; } = null;

        /// <summary>
        /// Доп. свойство для сохранения каждого отдельного человека в виде 'id.json'.
        /// </summary>
        [JsonPropertyName("Идентефикационный номер")]
        public string Id { get; set; }

        public Client(string surname, string name, string patronymic, string phoneNumber, string documentData, string id)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            DocumentData = documentData;
            Id = id;
        }

        /// <summary>
        /// Сохранение в JSON file.
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(Path.Combine(path, $"Client{Id}.json")), FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<Client>(fs, this);
            }
        }
    }
}