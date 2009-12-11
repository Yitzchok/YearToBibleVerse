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
              {'à', 1},{'á', 2},{'â', 3},{'ã', 4},{'ä', 5},{'å', 6},{'æ', 7},{'ç', 8},{'è', 9},{'é', 10},
              {'ë', 20},{'ê', 20},{'ì', 30},{'î', 40},{'í', 40},{'ð', 50},{'ï', 50},{'ñ', 60},{'ò', 70},
              {'ô', 80},{'ó', 80},{'ö', 90},{'õ', 90},{'÷', 100},{'ø', 200},{'ù', 300},{'ú', 400}
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