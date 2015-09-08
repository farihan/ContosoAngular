using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hans.MvcKnockout.Core.Commons;
using System.Reflection;

namespace Hans.Contoso.Core
{
    public class SessionFactoryPersistent
    {
        public NHibernate.ISessionFactory Initialize()
        {
            var sf = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c.FromConnectionStringWithKey(KeyType.Connection))
                    .Raw("prepare_sql", "true")
                    .Raw("cache.use_query_cache", "true")
                    .Raw("cache.use_second_level_cache", "true")
                    .DoNot
                    .ShowSql()
                )
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load(AssemblyType.Core)))
                .BuildSessionFactory();

            return sf;
        }
    }
}
