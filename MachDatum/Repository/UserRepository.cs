using MachDatum.Entitites;

namespace MachDatum.Repository
{
    public class UserRepository : NHibernateRepository<User>
    {
        public UserRepository(IConfiguration configuration) :
            base(NHibernateHelper.OpenSession(configuration.GetConnectionString("database")))
        {

        }
    }
}
