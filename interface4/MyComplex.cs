using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace interface4
{
    public class MyComplex : IMyNumber<MyComplex>
    {
        private double re;
        private double im;

        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(re + that.re, im + that.im); //this. or b
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(re - that.re, im - that.im);
        }

        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex(re * that.re - im * that.im, re * that.im + im * that.re);
        }

        public MyComplex Divide(MyComplex that)
        {
            double denominator = that.re * that.re + that.im * that.im;
            if (denominator == 0)
                throw new DivideByZeroException("Знаменник не може дорівнювати нулю.");
            return new MyComplex((re * that.re + im * that.im) / denominator, (im * that.re - re * that.im) / denominator);
        }

        public override string ToString()
        {
            string sign = im >= 0 ? "+" : "-";
            return $"{re}{sign}{Math.Abs(im)}i";
        }

        //Equals
        private const double Epsilon = 1e-10;

        public override bool Equals(object obj)
        {
            if (obj is MyComplex other)
            {
                return Math.Abs(this.re - other.re) < Epsilon &&
                       Math.Abs(this.im - other.im) < Epsilon;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(re, im);
        }
    }
}
