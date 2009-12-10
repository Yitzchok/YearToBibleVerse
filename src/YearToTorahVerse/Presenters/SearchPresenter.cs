using System.Collections.Generic;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;
using YearToTorahVerse.Core;
using YearToTorahVerse.Core.Services;
using YearToTorahVerse.Infrastructure;

namespace YearToTorahVerse.Presenters
{
    [Singleton(typeof(SearchPresenter))]
    public class SearchPresenter : Presenter
    {
        readonly IYearToVerseSearchService searchService;

        public SearchPresenter(IYearToVerseSearchService searchService)
        {
            this.searchService = searchService;
            jewishYear = new Observable<string>();
            Verses = new BindableCollection<Verse>();
        }

        Observable<string> jewishYear;
        public string JewishYear
        {
            get { return jewishYear.Value; }
            set { jewishYear.Value = value; }
        }

        IObservableCollection<Verse> Verses { get; set; }

        public IEnumerable<IResult> Save()
        {
            IList<Verse> verses = searchService.Search(int.Parse(JewishYear));

            verses.Clear();
            foreach (var verse in verses)
            {
                Verses.Add(verse);
            }

            yield break;
        }
    }
}