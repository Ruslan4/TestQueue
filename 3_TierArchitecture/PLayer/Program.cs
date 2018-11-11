using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;


namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleBLL peopleBLL = new PeopleBLL();

            Console.WriteLine($"Сейчас есть {peopleBLL.CountStudent()} студентов.");

            peopleBLL.ShowAllSudents();
        }
    }
}
