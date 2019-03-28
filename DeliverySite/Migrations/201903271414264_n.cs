namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commands", "ClientId", "dbo.AspNetUsers");
            DropIndex("dbo.Commands", new[] { "ClientId" });
            AddColumn("dbo.Commands", "Client_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Commands", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Commands", "Client_Id");
            AddForeignKey("dbo.Commands", "Client_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commands", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Commands", new[] { "Client_Id" });
            AlterColumn("dbo.Commands", "ClientId", c => c.String(maxLength: 128));
            DropColumn("dbo.Commands", "Client_Id");
            CreateIndex("dbo.Commands", "ClientId");
            AddForeignKey("dbo.Commands", "ClientId", "dbo.AspNetUsers", "Id");
        }
    }
}
