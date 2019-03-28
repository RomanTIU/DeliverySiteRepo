namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Command : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Commands", new[] { "Client_Id" });
            DropColumn("dbo.Commands", "ClientId");
            RenameColumn(table: "dbo.Commands", name: "Client_Id", newName: "ClientId");
            AlterColumn("dbo.Commands", "ClientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Commands", "ClientId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Commands", new[] { "ClientId" });
            AlterColumn("dbo.Commands", "ClientId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Commands", name: "ClientId", newName: "Client_Id");
            AddColumn("dbo.Commands", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Commands", "Client_Id");
        }
    }
}
