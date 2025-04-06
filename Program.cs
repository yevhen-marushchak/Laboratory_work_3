using System;
using System.Text;

namespace Laboratory_work_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ConsoleMenu menu = new ConsoleMenu();
            menu.Start();
        }
    }
}