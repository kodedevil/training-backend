using MachDatum.Entitites;

namespace MachDatum.Repository
{
    public class TeamsRepository : NHibernateRepository<Team>
    {
        public TeamsRepository(IConfiguration configuration) :
            base(NHibernateHelper.OpenSession(configuration.GetConnectionString("database")))
        {

        }
    }
}
