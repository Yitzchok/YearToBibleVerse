using Caliburn.PresentationFramework.ApplicationModel;
using NHibernate;

namespace YearToTorahVerse.Presenters
{
    public class SearchPresenter : Presenter
    {
        readonly ISessionFactory sessionFactory;

        public SearchPresenter(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }
    }
}