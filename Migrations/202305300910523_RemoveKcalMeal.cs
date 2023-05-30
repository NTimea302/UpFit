namespace UpFit__main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveKcalMeal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meals", "KcalMeal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "KcalMeal", c => c.Int(nullable: false));
        }
    }
}
