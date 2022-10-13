using FluentNHibernate.Mapping;

namespace MachDatum.Entitites
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; } = String.Empty;
        public virtual string DisplayName { get; set; } = String.Empty;
        public virtual int Age { get; set; } = 0;
    }

    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Id(x => x.ID).GeneratedBy.Native("users_id_seq");
            Map(x => x.Name)
                .Column("name")
                .Not.Nullable()
                .Length(32);
            Map(x => x.DisplayName)
                .Column("display_name")
                .Nullable();
            Map(x => x.Age)
                .Column("age")
                .Nullable();
            Table("users");
        }
    }
}
