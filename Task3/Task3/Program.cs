using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Если работу ведет консультант, введите 0, иначе любой другой символ: ");
                string? str = Console.ReadLine();

                Employer employer = new Manager("Manager", "0");
                if (str != null && str.Length == 1 && str[0] == '0')
                    employer = new Consultant("Consultant", "0");

                break;
                /// Далее можно написать различные запросы и тд. но у нас нет
            }

            Test test = new Test();

            test.CreateClients();
            test.CreateEmployers();

            test.TestClientLoad("0");
            test.TestClientLoad("1");
            test.TestClientLoad("4");

            test.TestManagerFunctionality("1");
        }
    }
}