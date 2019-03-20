namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manufacturers", "ImagePathLoggo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Manufacturers", "ImagePathLoggo");
        }
    }
}
