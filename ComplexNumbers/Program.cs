using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComplexNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            /*   ComplexNumber.Real r = new ComplexNumber.Real(2.0f);
               ComplexNumber.Imaginary i = new ComplexNumber.Imaginary(4.0f);
               ComplexNumber.Real r1 = new ComplexNumber.Real(1.0f);
               ComplexNumber.Imaginary i1 = new ComplexNumber.Imaginary(6.0f);
               ComplexNumber c1 = new ComplexNumber(r, i);
               ComplexNumber c2 = new ComplexNumber(r1, i1);
               c1.Representation();
               c2.Representation();
               ComplexNumber c3 = c1 + c2;
               c3.Representation();
               ComplexNumber c4 = c1 * c2;
               c4.Representation(); */
            ComplexNumber.Real r2 = new ComplexNumber.Real(0.0f);
            ComplexNumber.Imaginary i2 = new ComplexNumber.Imaginary(-4.0f);
            ComplexNumber c5 = new ComplexNumber(r2, i2);
            string d = ComplexNumber.ArgumentToString(c5);
            Console.Write(d);
        }


    }
}