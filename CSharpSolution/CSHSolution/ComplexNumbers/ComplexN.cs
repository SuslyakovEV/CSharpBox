using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexNumbers
{
    public class ComplexN

    {
        public double Imaginary { get; private set; }

        public double Real { get; private set; }

        public ComplexN(double imaginary, double real)
        {
            Imaginary = imaginary;
            Real = real;
        }

        private ComplexN()
        {

        }

        public ComplexN Plus(ComplexN other)
        {
            var complex = new ComplexN();
            complex.Imaginary = other.Imaginary + Imaginary;
            complex.Real = other.Real + Real;

            return complex;

        }

        public ComplexN Minus(ComplexN other)
        {
            var complex = new ComplexN();
            complex.Imaginary = other.Imaginary - Imaginary;
            complex.Real = other.Real - Real;

            return complex;

        }

    }
}
