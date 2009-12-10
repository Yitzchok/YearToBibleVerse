namespace YearToTorahVerse.Framework.Hebrew
{
    public interface IHebrewNumberConverter
    {
        string IntToHebrewNumber(int number);
        int HebrewNumberToInt(string hebrewNumber);
    }
}