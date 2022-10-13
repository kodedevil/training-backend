using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using MachDatum.Entitites;

namespace MachDatum
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static string _connectionString;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(PostgreSQLConfiguration.Standard
                        .ConnectionString(_connectionString))
                        .Mappings(m => m.FluentMappings
                            .Add<UserMapping>()
                            .Add<TeamMapping>())
                        .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static NHibernate.ISession OpenSession(string connectionString)
        {
            _connectionString = connectionString;
            return SessionFactory.OpenSession();
        }
    }
}
