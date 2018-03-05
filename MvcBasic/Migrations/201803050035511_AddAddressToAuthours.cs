namespace MvcBasic.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddAddressToAuthours : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Address_Prefecture = c.String(),
                    Address_City = c.String(),
                    Address_Street = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Authors", "Address", c => c.String(defaultValue: "UnKnown"));
        }

        public override void Down()
        {
            DropColumn("dbo.Authors", "Address");
            DropTable("dbo.People");
        }
    }
}
