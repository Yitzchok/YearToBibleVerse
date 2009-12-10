using FluentNHibernate.Mapping;

namespace YearToTorahVerse.Core.Mappings
{
    public class VerseInfoMap : ClassMap<Verse>
    {
        public VerseInfoMap()
        {
            Table("Verses");
            Id(c => c.VerseIndex).GeneratedBy.Assigned();
            Map(c => c.Book);
            Map(c => c.Chapter);
            Map(c => c.VerseNumber);
            Map(c => c.HebrewScripture);
        }
    }
}