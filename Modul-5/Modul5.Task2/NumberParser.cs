using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5.Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException();
            }

            stringValue = stringValue.Trim();

            if (string.IsNullOrEmpty(stringValue))
            {
                throw new FormatException();
            }

            bool isNegative = false;
            int i = 0;
            if (stringValue[i] == '-')
            {
                isNegative = true;
                i++;
            }
            else if (stringValue[i] == '+')
            {
                i++;
            }

            int number = 0;
            while (i < stringValue.Length)
            {
                int digit = stringValue[i++] - '0';
                if (digit < 0 || digit > 9)
                {
                    throw new FormatException();
                }

                if (isNegative)
                {
                    if (number < (int.MinValue + digit) / 10)
                    {
                        throw new OverflowException();
                    }
                    number = number * 10 - digit;
                }
                else
                {
                    if (number > (int.MaxValue - digit) / 10)
                    {
                        throw new OverflowException();
                    }
                    number = number * 10 + digit;
                }
            }

            return number;
        }
    }
}
