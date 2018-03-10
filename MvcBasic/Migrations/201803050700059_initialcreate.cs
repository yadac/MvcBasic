namespace MvcBasic.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                {
                    Id = c.Int(false, true),
                    Url = c.String(),
                    Title = c.String(),
                    Category = c.Int(false),
                    Description = c.String(),
                    ViewCount = c.Int(false),
                    Published = c.DateTime(false),
                    Released = c.Boolean(false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Authors",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    Email = c.String(),
                    Birth = c.DateTime(false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Comments",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    Body = c.String(),
                    Updated = c.DateTime(false),
                    ArticleId = c.Int(false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, true)
                .Index(t => t.ArticleId);

            CreateTable(
                "dbo.Members",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    Email = c.String(),
                    Birth = c.DateTime(false),
                    Married = c.Boolean(false),
                    Language = c.Int(false),
                    Memo = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.People",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    Address_Prefecture = c.String(),
                    Address_City = c.String(),
                    Address_Street = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AuthorArticles",
                c => new
                {
                    Author_Id = c.Int(false),
                    Article_Id = c.Int(false),
                })
                .PrimaryKey(t => new { t.Author_Id, t.Article_Id })
                .ForeignKey("dbo.Authors", t => t.Author_Id, true)
                .ForeignKey("dbo.Articles", t => t.Article_Id, true)
                .Index(t => t.Author_Id)
                .Index(t => t.Article_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.AuthorArticles", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.AuthorArticles", "Author_Id", "dbo.Authors");
            DropIndex("dbo.AuthorArticles", new[] { "Article_Id" });
            DropIndex("dbo.AuthorArticles", new[] { "Author_Id" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropTable("dbo.AuthorArticles");
            DropTable("dbo.People");
            DropTable("dbo.Members");
            DropTable("dbo.Comments");
            DropTable("dbo.Authors");
            DropTable("dbo.Articles");
        }
    }
}
