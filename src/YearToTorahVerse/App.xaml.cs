using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Castle;
using Caliburn.Core;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using YearToTorahVerse.Core.Mappings;
using YearToTorahVerse.Core.Services;
using YearToTorahVerse.Framework.Hebrew;
using YearToTorahVerse.Presenters;

namespace YearToTorahVerse
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IWindsorContainer container;
        private const string proxyFactory = "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle";

        public App()
        {
            CaliburnFramework.ConfigureCore(CreateContainer())
                .AfterStart(() =>
                {
                    var binder = (DefaultBinder)ServiceLocator.Current.GetInstance<IBinder>();
                    binder.EnableMessageConventions();
                    binder.EnableBindingConventions();
                })
                .WithAssemblies(Assembly.GetEntryAssembly())
                .WithPresentationFramework()
                .Start();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var binder = container.Resolve<IBinder>();
            var viewStrategy = container.Resolve<IViewStrategy>();

            var searchPresenter = container.Resolve<SearchPresenter>();

            object view = viewStrategy.GetView(searchPresenter, null, null);
            binder.Bind(searchPresenter, view, null);

            MainWindow = view as Window;

            //MainWindow.Show();
        }

        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <returns></returns>
        protected IContainer CreateContainer()
        {
            container = new WindsorContainer();
            var windsorAdapter = new WindsorAdapter(container);

            SetupContainer();

            return windsorAdapter;
        }

        void SetupContainer()
        {

            ISessionFactory dataSessionFactory = LoadDB();

            container.Register(
                Component.For<IHebrewNumberConverter>().ImplementedBy<HebrewNumberConverter>().LifeStyle.Singleton,
                Component.For<IYearToVerseSearchService>().ImplementedBy<YearToVerseSearchService>(),
                Component.For<ISessionFactory>().Named("MainDatabase").Instance(dataSessionFactory)
                );

        }

        static ISessionFactory LoadDB()
        {
            return Fluently.Configure().Database(() =>
                                                 SQLiteConfiguration
                                                     .Standard.UsingFile(@"VerseDatabase.db")
                                                     .ProxyFactoryFactory(proxyFactory)
                ).ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, true))
                .Mappings(m => m.FluentMappings.Add<VerseInfoMap>())
                .BuildConfiguration()
                .BuildSessionFactory();
        }
    }
}
