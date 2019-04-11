namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinusDeliverr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commands", "DeliveryManId", "dbo.DeliveryMen");
            DropIndex("dbo.Commands", new[] { "DeliveryManId" });
            AddColumn("dbo.DeliveryMen", "ComandId", c => c.String());
            AddColumn("dbo.DeliveryMen", "Command_Id", c => c.Int());
            CreateIndex("dbo.DeliveryMen", "Command_Id");
            AddForeignKey("dbo.DeliveryMen", "Command_Id", "dbo.Commands", "Id");
            DropColumn("dbo.Commands", "DeliveryManId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Commands", "DeliveryManId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DeliveryMen", "Command_Id", "dbo.Commands");
            DropIndex("dbo.DeliveryMen", new[] { "Command_Id" });
            DropColumn("dbo.DeliveryMen", "Command_Id");
            DropColumn("dbo.DeliveryMen", "ComandId");
            CreateIndex("dbo.Commands", "DeliveryManId");
            AddForeignKey("dbo.Commands", "DeliveryManId", "dbo.DeliveryMen", "Id", cascadeDelete: true);
        }
    }
}
