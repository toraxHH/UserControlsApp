using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControls.Models;


namespace TestUserControlsConsole
{
    internal class Program
    {
        static void Main()
        {
            long val = -1;           

            while (val != 0) 
            {
                Console.WriteLine("Size in Bytes (0 = Quit)");
                val = Convert.ToInt64(Console.ReadLine());
                SizeInformation bi = new SizeInformation(Convert.ToInt64(val));                
                Console.WriteLine(bi.SizeOutput);
            }
        }
    }
}
