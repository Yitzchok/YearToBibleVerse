using FluentNHibernate.Mapping;

namespace YearToTorahVerse.Core.Mappings
{
    public class VerseInfoMap : ClassMap<VerseInfo>
    {
        public VerseInfoMap()
        {
            Table("VerseInfo");
            Id(c => c.VerseNumber).GeneratedBy.Assigned();
            Map(c => c.Book);
            Map(c => c.Chapter);
            Map(c => c.Verse);
            Map(c => c.HebrewScripture);
        }
    }
}