namespace MvcBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomethingChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        UserAgent = c.String(),
                        Accessed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccessLogs");
        }
    }
}
