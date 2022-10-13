using FluentMigrator;

namespace MachDatum.Migrations
{
    [Migration(202203)]
    public class TeamsMigration : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            if (!Schema.Table("teams").Exists())
            {
                Create.Table("teams")
                    .WithColumn("id").AsInt32().PrimaryKey("teams_pkey")
                    .Identity()
                    .WithColumn("name").AsString(32).NotNullable();
            }
        }
    }
}
