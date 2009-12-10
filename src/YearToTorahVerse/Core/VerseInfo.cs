namespace YearToTorahVerse.Core
{
    public class VerseInfo
    {
        public virtual int VerseNumber { get; set; }
        public virtual int Book { get; set; }
        public virtual string Chapter { get; set; }
        public virtual string Verse { get; set; }
        public virtual string HebrewScripture { get; set; }
    }
}