using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();

            test.CreateClients();
            test.CreateEmployers();

            test.TestClientLoad("0");
            test.TestClientLoad("1");
            test.TestClientLoad("4");
        }
    }
}