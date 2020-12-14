using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, n;

            Console.WriteLine("Input 3 integers and see what the algorithm produces\nFirst int = a, Second int = b, Third int = n\nThe algorithm is as follows" +
                " a + 1 * b + 2 * b + 3 * b... until it reaches n\n");

            Console.WriteLine("This is a test");
            Console.WriteLine("First int: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Second int: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Third int: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n" + a + " " + b + " " + n + "\n");
            
            double c = a;
            // y keeps track of when to end the loop.
            for (int y = 0; y < n; y++)
            {
                c += Math.Pow(2, y) * b;
                Console.WriteLine(c + " ");
            }
        }
    }
}

