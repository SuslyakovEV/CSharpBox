using System;
using ComplexNumbers;


namespace ComplexNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexN c1 = new ComplexN(1, 1);
            ComplexN c2 = new ComplexN(1, 2);

            ComplexN result = c1.Plus(c2);
            Console.WriteLine($"Result of Plus: Real = {result.Real}; Imaginary={result.Imaginary}");

            result = c1.Minus(c2);
            Console.WriteLine($"Result of Minus: Real = {result.Real}; Imaginary={result.Imaginary}");


            Console.ReadKey();


        }
    }
}
