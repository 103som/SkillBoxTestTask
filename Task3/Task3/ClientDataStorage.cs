using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task3
{
    static internal class ClientDataStorage
    {
        private static string pathClients { get; }

        static ClientDataStorage()
        {
            pathClients = Path.GetFullPath(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            pathClients = Path.GetFullPath(Path.Combine(pathClients, "Clients"));
            Directory.CreateDirectory(pathClients);
        }

        public static void SaveClients()
        {
            foreach (Client client in Bank.getBank().GetClients().Values)
                client.Save(pathClients);
        }

        public static void AutoLoadClients()
        {
            DirectoryInfo di = new DirectoryInfo(pathClients);
            foreach (FileInfo fi in di.GetFiles())
            {
                using (FileStream fs = File.OpenRead(fi.ToString()))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string str = Encoding.Default.GetString(buffer);

                    var client = JsonSerializer.Deserialize<Client>(str);
                    Bank.getBank().AddClient(client);
                }
            }
        }

        public static void downloadClient(int pos)
        {
            DirectoryInfo di = new DirectoryInfo(pathClients);
            var files = di.GetFiles();

            if (pos >= files.Count())
                throw new ArgumentOutOfRangeException();

            using (FileStream fs = File.OpenRead(files[pos].ToString()))
            {
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string str = Encoding.Default.GetString(buffer);
                    Bank.getBank().AddClient(JsonSerializer.Deserialize<Client>(str));
                }
            }
        }
    }
}