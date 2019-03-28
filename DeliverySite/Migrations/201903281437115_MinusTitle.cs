namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinusTitle : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Title", c => c.String(nullable: false));
        }
    }
}
