namespace MvcBasic.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeNotNullableOnCommentsArticleId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Article_Id", "dbo.Articles");
            DropIndex("dbo.Comments", new[] { "Article_Id" });
            AlterColumn("dbo.Comments", "Article_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "Article_Id");
            AddForeignKey("dbo.Comments", "Article_Id", "dbo.Articles", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Article_Id", "dbo.Articles");
            DropIndex("dbo.Comments", new[] { "Article_Id" });
            AlterColumn("dbo.Comments", "Article_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Article_Id");
            AddForeignKey("dbo.Comments", "Article_Id", "dbo.Articles", "Id");
        }
    }
}
