using System.Collections.Generic;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;
using YearToTorahVerse.Core;
using YearToTorahVerse.Core.Services;
using YearToTorahVerse.Framework.Hebrew;
using YearToTorahVerse.Infrastructure;

namespace YearToTorahVerse.Presenters
{
    [Singleton(typeof(SearchPresenter))]
    public class SearchPresenter : Presenter
    {
        readonly IYearToVerseSearchService searchService;
        readonly IHebrewNumberConverter hebrewNumberConverter;

        public SearchPresenter(IYearToVerseSearchService searchService, IHebrewNumberConverter hebrewNumberConverter)
        {
            this.searchService = searchService;
            this.hebrewNumberConverter = hebrewNumberConverter;
            jewishYear = new Observable<string>("5770");
            Verses = new BindableCollection<Verse>();
        }

        Observable<string> jewishYear;
        public string JewishYear
        {
            get { return jewishYear.Value; }
            set
            {
                jewishYear.Value = value;
                NotifyOfPropertyChange("CanSearch");
            }
        }

        public IObservableCollection<Verse> Verses { get; set; }

        public IEnumerable<IResult> Search()
        {
            int year;

            int.TryParse(JewishYear, out year);

            if (year < 1)
                year = hebrewNumberConverter.HebrewNumberToInt(JewishYear);

            IList<Verse> verses = searchService.Search(year);

            Verses.Clear();
            foreach (var verse in verses)
            {
                Verses.Add(verse);
            }

            yield break;
        }

        public bool CanSearch
        {
            get
            {
                int hu;
                if (int.TryParse(JewishYear, out hu))
                    return true;

                return hebrewNumberConverter.IsValidHebrewNumber(JewishYear);
            }
        }
    }
}