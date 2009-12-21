using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace YearToTorahVerse.Core.Services
{
    public interface IYearToVerseSearchService
    {
        IList<Verse> Search(int jewishYear);
    }

    public class YearToVerseSearchService : IYearToVerseSearchService
    {
        readonly ISessionFactory factory;

        public YearToVerseSearchService(ISessionFactory factory)
        {
            this.factory = factory;
        }

        public IList<Verse> Search(int jewishYear)
        {
            IList<Verse> versesToReturn = null;
            using (ISession session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var verses = from verse in session.Linq<Verse>()
                                     where verse.VerseIndex >= jewishYear - 2 && verse.VerseIndex < jewishYear + 3
                                     select verse;

                        versesToReturn = verses.ToList();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }

            return versesToReturn;
        }
    }
}