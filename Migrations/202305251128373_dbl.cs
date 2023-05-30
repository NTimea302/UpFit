namespace UpFit__main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "calories", c => c.Double());
            AlterColumn("dbo.Foods", "proteins", c => c.Double());
            AlterColumn("dbo.Foods", "fats", c => c.Double());
            AlterColumn("dbo.Foods", "carbs", c => c.Double());
            AlterColumn("dbo.Foods", "fibers", c => c.Double());
            AlterColumn("dbo.Foods", "vitamin_A", c => c.Double());
            AlterColumn("dbo.Foods", "vitamin_B", c => c.Double());
            AlterColumn("dbo.Foods", "vitamin_C", c => c.Double());
            AlterColumn("dbo.Foods", "vitamin_D", c => c.Double());
            AlterColumn("dbo.Foods", "vitamin_E", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "vitamin_E", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "vitamin_D", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "vitamin_C", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "vitamin_B", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "vitamin_A", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "fibers", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "carbs", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "fats", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "proteins", c => c.Single(nullable: false));
            AlterColumn("dbo.Foods", "calories", c => c.Single(nullable: false));
        }
    }
}
