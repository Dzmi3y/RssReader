using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            bool exit = false;

            ConsoleManager manager = new ConsoleManager();

            while (!exit)
            {
                Console.WriteLine("1: LoadRss");
                Console.WriteLine("Exit: any key");
                Console.WriteLine("");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine("");

                switch (key)
                {
                    case '1': manager.LoadRss(); GetInfo(manager.GetInfo()); break;
                    default: exit = true; break;
                }
            }
        }

        static void GetInfo(List<string> infoList)
        {
            foreach(var item in infoList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

        }
    }
}