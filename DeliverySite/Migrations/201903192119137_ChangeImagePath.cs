namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image1", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Image1");
        }
    }
}
