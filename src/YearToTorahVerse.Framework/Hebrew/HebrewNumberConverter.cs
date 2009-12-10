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
            hebrewChars.Add('à', 1);
            hebrewChars.Add('á', 2);
            hebrewChars.Add('â', 3);
            hebrewChars.Add('ã', 4);
            hebrewChars.Add('ä', 5);
            hebrewChars.Add('å', 6);
            hebrewChars.Add('æ', 7);
            hebrewChars.Add('ç', 8);
            hebrewChars.Add('è', 9);
            hebrewChars.Add('é', 10);
            hebrewChars.Add('ë', 20);
            hebrewChars.Add('ê', 20);
            hebrewChars.Add('ì', 30);
            hebrewChars.Add('î', 40);
            hebrewChars.Add('í', 40);
            hebrewChars.Add('ð', 50);
            hebrewChars.Add('ï', 50);
            hebrewChars.Add('ñ', 60);
            hebrewChars.Add('ò', 70);
            hebrewChars.Add('ô', 80);
            hebrewChars.Add('ó', 80);
            hebrewChars.Add('ö', 90);
            hebrewChars.Add('õ', 90);
            hebrewChars.Add('÷', 100);
            hebrewChars.Add('ø', 200);
            hebrewChars.Add('ù', 300);
            hebrewChars.Add('ú', 400);
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