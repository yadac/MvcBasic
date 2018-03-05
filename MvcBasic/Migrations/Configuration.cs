namespace MvcBasic.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcBasic.Models.MvcBasicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MvcBasic.Models.MvcBasicContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MvcBasic.Models.MvcBasicContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
