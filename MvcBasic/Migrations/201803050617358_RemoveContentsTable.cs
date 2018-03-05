namespace MvcBasic.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveContentsTable : DbMigration
    {
        public override void Up()
        {
            // RenameColumn(table: "dbo.Articles", name: "Note", newName: "Description");
            AlterColumn("dbo.Articles", "Description", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.Articles", "Description", c => c.String(storeType: "ntext"));
            // RenameColumn(table: "dbo.Articles", name: "Description", newName: "Note");
        }
    }
}
