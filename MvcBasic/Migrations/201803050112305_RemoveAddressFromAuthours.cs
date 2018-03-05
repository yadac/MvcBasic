namespace MvcBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAddressFromAuthours : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Address", c => c.String());
        }
    }
}
