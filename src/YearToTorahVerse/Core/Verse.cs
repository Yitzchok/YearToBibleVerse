namespace YearToTorahVerse.Core
{
    public class Verse
    {
        public virtual int VerseIndex { get; set; }
        public virtual int Book { get; set; }
        public virtual int Chapter { get; set; }
        public virtual int VerseNumber { get; set; }
        public virtual string HebrewScripture { get; set; }
    }
}