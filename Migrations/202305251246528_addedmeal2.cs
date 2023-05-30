namespace UpFit__main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmeal2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        mealID = c.Int(nullable: false, identity: true),
                        mealTypeFK = c.Int(nullable: false),
                        userFK = c.Int(nullable: false),
                        foodFK = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.mealID);
            
            CreateTable(
                "dbo.MealTypes",
                c => new
                    {
                        mealTypeID = c.Int(nullable: false, identity: true),
                        mealName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.mealTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MealTypes");
            DropTable("dbo.Meals");
        }
    }
}
