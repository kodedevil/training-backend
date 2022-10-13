using FluentMigrator;

namespace MachDatum.Migrations
{
    [Migration(202202)]
    public class SecondMigration : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Rename.Column("displayName")
                .OnTable("users")
                .To("display_name");
        }
    }
}
