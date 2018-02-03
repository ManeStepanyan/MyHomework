using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComplexNumber


{
    public class ComplexNumbers

    {
        public struct Real
        {
            public float a;  //a+ib
            public Real(float a)
            {
                this.a = a;
            }
        }
        public struct Imaginary
        {
            public float b;
            public Imaginary(float b)
            {
                this.b = b;
            }
        }
        Real real;
        Imaginary imaginary;
        public ComplexNumber(Real r, Imaginary i)
        {
            real.a = r.a;
            imaginary.b = i.b;

        }
        public ComplexNumber()
        {
            real.a = 0.0f;
            imaginary.b = 0.0f;

        }

        public static ComplexNumber operator +(ComplexNumber first, ComplexNumber second)
        {
            Real r;
            Imaginary i;
            float a = first.real.a + second.real.a;
            float b = first.imaginary.b + second.imaginary.b;
            r.a = a;
            i.b = b;

            return (new ComplexNumber(r, i));

        }
        public static ComplexNumber operator -(ComplexNumber first, ComplexNumber second)
        {
            Real r;
            Imaginary i;
            float a = first.real.a - second.real.a;
            float b = first.imaginary.b - second.imaginary.b;
            r.a = a;
            i.b = b;

            return (new ComplexNumber(r, i));

        }
        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second)
        {
            Real r;
            Imaginary i;
            float ac = first.real.a * second.real.a;
            float bd = first.imaginary.b * second.imaginary.b;
            float ad = first.real.a * second.imaginary.b;
            float bc = first.imaginary.b * second.real.a;

            r.a = ac - bd; // (ac-bd) is real part of complex number
            i.b = bc + ad; //(bc+ad) is imaginary part of complex number
            //as (a+bi)*(c+di)=(ac-bd) + i(bc+ad)
            return (new ComplexNumber(r, i));

        }
        public static ComplexNumber operator /(ComplexNumber first, ComplexNumber second)
        {
            if (second.real.a == 0.0 && second.imaginary.b == 0.0)
                throw new DivideByZeroException("Can't devide by zero");
            Real r;
            Imaginary i;
            float ac = first.real.a * second.real.a;
            float bd = first.imaginary.b * second.imaginary.b;
            float ad = first.real.a * second.imaginary.b;
            float bc = first.imaginary.b * second.real.a;
            float csquare = second.real.a * second.real.a;
            float dsquare = second.imaginary.b * second.imaginary.b;
            r.a = (ac + bd) / (csquare + dsquare); //real part
            i.b = (bc - ad) / (csquare + dsquare); //imaginary part
            //as (a+ib)/(c+id)= (ac+bd)/(a^2+b^2) + (bc-ad)/(a^2+b^2)
            return (new ComplexNumber(r, i));


        }
        public static ComplexNumber Add(ComplexNumber c1, ComplexNumber c2)
        {
            return (c1 + c2);
        }

        public static ComplexNumber Subtract(ComplexNumber c1, ComplexNumber c2)
        {
            return (c1 - c2);
        }

        public static ComplexNumber Multiply(ComplexNumber c1, ComplexNumber c2)
        {
            return (c1 * c2);
        }

        public static ComplexNumber Divide(ComplexNumber c1, ComplexNumber c2)
        {
            return (c1 / c2);
        }
        public double AbsoluteValue(ComplexNumber c)
        {
            float r = c.real.a;
            float i = c.imaginary.b;
            r *= r;
            i *= i;
            double d = (double)(r + i);
            d = Math.Sqrt(d);
            return d;

        }
        public double Argument(ComplexNumber z)
        {
            float a = z.real.a;
            float b = z.imaginary.b;
            double div = a / b;
            if (a > 0)
            {
                return Math.Atan(div);
            }
            if (a < 0 && (b > 0 || b == 0))
            {
                return Math.PI + Math.Atan(div);
            }
            if (a < 0 && b < 0)
            {
                return Math.Atan(div) - Math.PI;
            }
            if (a == 0 && b > 0)
                return Math.PI / 2;
            if (a == 0 && b < 0)
                return -Math.PI / 2;
            else throw new Exception(" The value is not determined");
        }
        public static String ArgumentToString(ComplexNumber z)
        {
            float a = z.real.a;
            float b = z.imaginary.b;

            if (a > 0)
            {
                return "Arctg(" + b + "/" + a + ")";
            }
            if (a < 0 && (b > 0 || b == 0))
            {
                return "PI" + "Arctg(" + b + "/" + a + ")";
            }
            if (a < 0 && b < 0)
            {
                return "Arctg(" + b + "/" + a + ")" + " -" + "PI";
            }
            if (a == 0 && b > 0)
                return "PI" + " /" + "2";
            if (a == 0 && b < 0)
                return "-" + "PI" + "/" + "2";
            else throw new Exception(" The value is not determined");
        }
        public void Representation() //Representation of complex number in suitable form
        {
            Console.WriteLine(real.a + "+" + imaginary.b + "i");
        }
    }
}