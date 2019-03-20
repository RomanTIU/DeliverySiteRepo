namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinusImageByte : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Image1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Image1", c => c.Binary());
        }
    }
}
