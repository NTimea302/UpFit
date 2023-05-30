namespace UpFit__main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyColumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Meals", "Type", "KcalMeal");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Meals", "KcalMeal", "Type");
        }
    }
}
