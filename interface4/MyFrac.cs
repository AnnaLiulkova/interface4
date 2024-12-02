using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace interface4
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private BigInteger nom; 
        private BigInteger denom;

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
                throw new DivideByZeroException("Знаменник не може дорівнювати нулю.");
            this.nom = nom;
            this.denom = denom;
            Simplify();
        }
        public MyFrac(int nom, int denom) : this((BigInteger)nom, (BigInteger)denom) 
        { }
        private void Simplify() 
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(nom, denom); //НСД
            nom /= gcd;
            denom /= gcd;
            if (denom < 0)
            {
                nom = -nom;
                denom = -denom;
            }
        }
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(nom * that.denom + that.nom * denom, denom * that.denom); //this. or b
        }

        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(nom * that.denom - that.nom * denom, denom * that.denom);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(nom * that.nom, denom * that.denom);
        }

        public MyFrac Divide(MyFrac that)
        {
            if (that.nom==0)
                throw new DivideByZeroException("Знаменник не може дорівнювати нулю.");
            return new MyFrac(nom * that.denom, that.nom * denom);
        }

        public override string ToString()
        {
            return $"{nom}/{denom}";
        }

        public int CompareTo(MyFrac other)
        {
            BigInteger diff = nom * other.denom - other.nom * denom;
            return diff < 0 ? -1 : (diff > 0 ? 1 : 0);
        }

        //Equals
        public override bool Equals(object obj)
        {
            if (obj is MyFrac other)
            {
                return this.nom * other.denom == other.nom * this.denom;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nom, denom);
        }
    }
}
