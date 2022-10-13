using FluentMigrator;

namespace MachDatum.Migrations
{
    [Migration(202201)]
    public class InitialMigration : Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {
            if (!Schema.Table("users").Exists())
            {
                Create.Table("users")
                     .WithColumn("id").AsInt32().PrimaryKey("user_pkey").Identity()
                     .WithColumn("name").AsString(32).NotNullable()
                     .WithColumn("displayName").AsString(255).Nullable()
                     .WithColumn("age").AsInt16().Nullable();
            }
        }
    }
}
