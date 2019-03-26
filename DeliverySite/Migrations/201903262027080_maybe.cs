namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maybe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commands", "DeliveryManId", "dbo.DeliveryMen");
            DropIndex("dbo.Commands", new[] { "DeliveryManId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Commands", "DeliveryManId");
            AddForeignKey("dbo.Commands", "DeliveryManId", "dbo.DeliveryMen", "Id", cascadeDelete: true);
        }
    }
}
