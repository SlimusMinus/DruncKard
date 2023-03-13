using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DruncKard
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;
            WriteLine("\n\n\n\t\tWelcome to game!!!");
            ReadLine();
            Clear();
l1:
            WriteLine("Выберите количество игрогов - 2 или 3");
            ConsoleKey key = ReadKey().Key;
            Clear();
            switch (key)
            {
                case ConsoleKey.D2:
                    {
                        Cards gm = new Cards();
                        gm.draw();
                        gm.Gamexin();
                    }
                    break;
                case ConsoleKey.D3:
                    {
                        _3_players cd = new _3_players();
                        cd.draw();
                        cd.GameIn_3players();
                    }
                    break;
                default:
                    {
                        WriteLine("\nThis number is error, press Enter");
                        goto l1;
                    }
                    break;
            }

        }
    }
}
