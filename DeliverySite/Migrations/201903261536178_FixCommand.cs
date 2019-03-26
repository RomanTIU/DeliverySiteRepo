namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCommand : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commands", "DeliveryMan_Id", "dbo.DeliveryMen");
            DropIndex("dbo.Commands", new[] { "DeliveryMan_Id" });
            RenameColumn(table: "dbo.Commands", name: "DeliveryMan_Id", newName: "DeliveryManId");
            AlterColumn("dbo.Commands", "DeliveryManId", c => c.Int(nullable: false));
            CreateIndex("dbo.Commands", "DeliveryManId");
            AddForeignKey("dbo.Commands", "DeliveryManId", "dbo.DeliveryMen", "Id", cascadeDelete: true);
            DropColumn("dbo.DeliveryMen", "CommandId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeliveryMen", "CommandId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Commands", "DeliveryManId", "dbo.DeliveryMen");
            DropIndex("dbo.Commands", new[] { "DeliveryManId" });
            AlterColumn("dbo.Commands", "DeliveryManId", c => c.Int());
            RenameColumn(table: "dbo.Commands", name: "DeliveryManId", newName: "DeliveryMan_Id");
            CreateIndex("dbo.Commands", "DeliveryMan_Id");
            AddForeignKey("dbo.Commands", "DeliveryMan_Id", "dbo.DeliveryMen", "Id");
        }
    }
}
