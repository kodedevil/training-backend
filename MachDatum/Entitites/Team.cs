using FluentNHibernate.Mapping;

namespace MachDatum.Entitites
{
    public class Team
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
    }

    public class TeamMapping: ClassMap<Team>
    {
        public TeamMapping()
        {
            Id(x => x.ID).Column("id").GeneratedBy.Native("teams_id_seq");
            Map(x => x.Name).Column("name").Length(32).Not.Nullable();
            Table("teams");
        }
    }
}
