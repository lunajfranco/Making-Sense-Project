using Making_Sense_Project.Logic;
using Making_Sense_Project.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            StartUp startUp = new StartUp();
            startUp.StartApp();
            Console.ReadKey();
        }
    }
}
