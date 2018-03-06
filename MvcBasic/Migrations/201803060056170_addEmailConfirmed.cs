namespace MvcBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailConfirmed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Memo", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Memo", c => c.String());
            AlterColumn("dbo.Members", "Name", c => c.String());
        }
    }
}
