namespace MvcBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Int(false, true),
                        Controller = c.String(),
                        Action = c.String(),
                        Message = c.String(),
                        Stacktrace = c.String(),
                        Updated = c.DateTime(false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ErrorLogs");
        }
    }
}
