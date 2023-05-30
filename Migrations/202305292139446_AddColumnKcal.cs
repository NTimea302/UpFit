namespace UpFit__main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnKcal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "Type",c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "Type");
        }
    }
}
