using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YearToTorahVerse.Framework.Hebrew
{
    public class HebrewNumberConverter : IHebrewNumberConverter
    {
        private readonly IDictionary<char, int> hebrewChars =
           new Dictionary<char, int>{
              {'�', 1},{'�', 2},{'�', 3},{'�', 4},{'�', 5},{'�', 6},{'�', 7},{'�', 8},{'�', 9},{'�', 10},
              {'�', 20},{'�', 20},{'�', 30},{'�', 40},{'�', 40},{'�', 50},{'�', 50},{'�', 60},{'�', 70},
              {'�', 80},{'�', 80},{'�', 90},{'�', 90},{'�', 100},{'�', 200},{'�', 300},{'�', 400}
           };

        public int HebrewNumberToInt(string hebrewNumber)
        {
            return hebrewNumber.Sum(letter => hebrewChars[letter]);
        }

        public string IntToHebrewNumber(int number)
        {
            var builder = new StringBuilder();

            int tempNumber = number;
            foreach (var hebrewChar in hebrewChars.Reverse()
                .TakeWhile(hebrewChar => tempNumber > 0))
            {
                while (tempNumber >= hebrewChar.Value)
                {
                    builder.Append(hebrewChar.Key);
                    tempNumber -= hebrewChar.Value;
                }
            }

            return builder.ToString();
        }
    }
}