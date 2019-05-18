using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ComplexNumbers
{
    class Complex : IFormattable
    {
        private System.Numerics.Complex ComplexNum { get; set; }

        public Complex(System.Numerics.Complex complex)
        {
            ComplexNum = complex;
        }

        public Complex(Double a , Double b)
        {
            ComplexNum = new System.Numerics.Complex(a, b);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.ComplexNum + b.ComplexNum);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.ComplexNum - b.ComplexNum);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            return new Complex(a.ComplexNum / b.ComplexNum);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.ComplexNum * b.ComplexNum);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "d";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "D":
                    return String.Format("{0} + {1}i", ComplexNum.Real, ComplexNum.Imaginary);
                case "W":
                    return String.Format("[{0},{1}]", ComplexNum.Real, ComplexNum.Imaginary);
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }

        }
    }
}
