namespace MvcBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimestampToArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Timestamp", c => c.Binary(false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Timestamp");
        }
    }
}
