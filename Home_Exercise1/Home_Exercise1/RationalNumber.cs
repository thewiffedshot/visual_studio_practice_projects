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
            int lowerNum = Math.Min(numerator, denominator);

            for (int i = 2; i <= lowerNum; i++)
            {
                if (numerator % i == 0 && denominator % i == 0)
                {
                    numerator /= i;
                    denominator /= i;

                    lowerNum = Math.Min(numerator, denominator);
                    i = 2;
                }
            }
        }

        public RationalNumber Add(RationalNumber rn)
        {
            int commonDenominator = denominator * rn.denominator;

            denominator = commonDenominator;
            rn.denominator = commonDenominator;

            numerator *= rn.denominator;
            rn.numerator *= denominator;

            RationalNumber result = new RationalNumber(numerator + rn.numerator, commonDenominator);

            Rationalize();

            return result;
        }
    }
}
