using System;

namespace Fibon
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of Fibonacci numbers you want to generate: ");
            int n = int.Parse(Console.ReadLine());

            int[] fibon = new int[n];

            int a0 = 0;
            int a1 = 1;

            fibon[0] = a0;
            fibon[1] = a1;

            for (int i=2; i<n; i++)
            {
                int a = a0 + a1;
                fibon[i] = a;

                a0 = a1;
                a1 = a;
            }

            Console.WriteLine("Fibonacci numbers: ");
            foreach (int cur in fibon)
                Console.Write(cur + " ");

            Console.ReadKey();
        }


    }


}
