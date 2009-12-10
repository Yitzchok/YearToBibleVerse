using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YearToTorahVerse.Framework.Hebrew
{
    public class HebrewNumberConverter : IHebrewNumberConverter
    {
        private IDictionary<char, int> hebrewChars = new Dictionary<char, int>();

        public HebrewNumberConverter()
        {
            hebrewChars.Add('�', 1);
            hebrewChars.Add('�', 2);
            hebrewChars.Add('�', 3);
            hebrewChars.Add('�', 4);
            hebrewChars.Add('�', 5);
            hebrewChars.Add('�', 6);
            hebrewChars.Add('�', 7);
            hebrewChars.Add('�', 8);
            hebrewChars.Add('�', 9);
            hebrewChars.Add('�', 10);
            hebrewChars.Add('�', 20);
            hebrewChars.Add('�', 20);
            hebrewChars.Add('�', 30);
            hebrewChars.Add('�', 40);
            hebrewChars.Add('�', 40);
            hebrewChars.Add('�', 50);
            hebrewChars.Add('�', 50);
            hebrewChars.Add('�', 60);
            hebrewChars.Add('�', 70);
            hebrewChars.Add('�', 80);
            hebrewChars.Add('�', 80);
            hebrewChars.Add('�', 90);
            hebrewChars.Add('�', 90);
            hebrewChars.Add('�', 100);
            hebrewChars.Add('�', 200);
            hebrewChars.Add('�', 300);
            hebrewChars.Add('�', 400);
        }

        public string IntToHebrewNumber(int number)
        {
            IList<Char> numbers = number.ToString().ToList();

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < numbers.Count; i++)
            {
                var num = numbers[i];

                int amountOfZeros = (numbers.Count - 1) - i;
                int cleanedNumber = int.Parse(num + GenerateZeros(amountOfZeros));

                if (cleanedNumber > 0)
                {
                    builder.Append(ExtractNumber(cleanedNumber));
                }
            }

            return builder.ToString();
        }

        private string ExtractNumber(int smallNumber)
        {
            if (smallNumber > 400)
            {
                string charsToReturn = ExtractNumber((smallNumber / 400) * 400);

                int leftOvers = smallNumber % 400;

                if (leftOvers > 0)
                {
                    charsToReturn += ExtractNumber(leftOvers);
                }

                return charsToReturn;
            }
            else
                return hebrewChars.First(c => c.Value == smallNumber).Key.ToString();
        }

        private string GenerateZeros(int amount)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < amount; i++)
            {
                builder.Append("0");
            }

            return builder.ToString();
        }

        public int HebrewNumberToInt(string hebrewNumber)
        {
            return hebrewNumber.Sum(letter => hebrewChars[letter]);
        }
    }
}