namespace UpFit__main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KcalIntFood : DbMigration
    {
        public override void Up()
        {
            
            AlterColumn("dbo.Foods", "calories", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "calories", c => c.Double(nullable: false));
           
        }
    }
}
