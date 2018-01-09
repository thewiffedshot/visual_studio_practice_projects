using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Exercise1
{
    class RationalNumber
    {
        private int numerator, denominator;

        public RationalNumber()
        {
            numerator = 0;
            denominator = 1;
        }

        public RationalNumber(int _numerator, int _denominator)
        {
            numerator = _numerator;
            denominator = _denominator;

            Rationalize();
        }

        public decimal ToDecimal()
        {
            return (decimal)numerator / denominator;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", numerator, denominator);
        }

        private void Rationalize()
        {
            int a = numerator, b = denominator, c;

            if (a > b)
            {
                while (true)
                {
                    c = a;
                    a = b;

                    if (c % b == 0) { numerator /= b; denominator /= b; break; }

                    b = c % b;                                        
                }
            }
            else if (a < b)
            {
                c = a;
                a = b;
                b = c;

                while (true)
                {
                    c = a;
                    a = b;

                    if (c % b == 0) { numerator /= b; denominator /= b; break; }

                    b = c % b;
                }
            }
            else
            {
                numerator = 1; denominator = 1;
            }

            if (denominator < 0) { numerator = -numerator; denominator = -denominator; }
        }

        public static RationalNumber operator +(RationalNumber rn, RationalNumber rn1)
        {
            int commonDenominator = rn.denominator * rn1.denominator;

            rn.numerator *= rn1.denominator;
            rn1.numerator *= rn.denominator;

            rn.denominator = commonDenominator;
            rn1.denominator = commonDenominator;

            RationalNumber result = new RationalNumber(rn.numerator + rn1.numerator, commonDenominator);

            rn.Rationalize();
            rn1.Rationalize();

            return result;
        }

        public static RationalNumber operator -(RationalNumber rn, RationalNumber rn1)
        {
            int commonDenominator = rn.denominator * rn1.denominator;

            rn.numerator *= rn1.denominator;
            rn1.numerator *= rn.denominator;

            rn.denominator = commonDenominator;
            rn1.denominator = commonDenominator;

            RationalNumber result = new RationalNumber(rn.numerator - rn1.numerator, commonDenominator);

            rn.Rationalize();
            rn1.Rationalize();

            return result;
        }

        public static RationalNumber operator -(RationalNumber rn)
        {
            rn.numerator = -rn.numerator;

            return rn;
        }

        public static RationalNumber operator *(RationalNumber rn, RationalNumber rn1)
        {
            RationalNumber result = new RationalNumber(rn.numerator * rn1.numerator, rn.denominator * rn1.denominator);
            return result;
        }

        public static RationalNumber operator /(RationalNumber rn, RationalNumber rn1)
        {
            RationalNumber result = new RationalNumber(rn.numerator / rn1.numerator, rn.denominator / rn1.denominator);
            return result;
        }
    }
}
