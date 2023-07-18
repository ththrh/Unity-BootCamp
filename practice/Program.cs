using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            string snum1 = Console.ReadLine();
            if (int.TryParse(snum1, out int testNum1))
            {
                num1 = int.Parse(snum1);
            }
            else
            {
                return;
            }
            string snum2 = Console.ReadLine();
            if (int.TryParse(snum2, out int testNum2))
            {
                num2 = int.Parse(snum2);
            }
            else
            {
                return;
            }
            Console.WriteLine(num1 + num2);
            Console.WriteLine(num1 - num2);
            Console.WriteLine(num1 * num2);
            Console.WriteLine(num1 / num2);
            Console.WriteLine(num1 % num2);
        }
    }
}
