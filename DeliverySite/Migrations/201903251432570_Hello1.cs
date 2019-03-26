namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hello1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Commands", "Client_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Commands", "Client_Id");
            AddForeignKey("dbo.Commands", "Client_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commands", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Commands", new[] { "Client_Id" });
            DropColumn("dbo.Commands", "Client_Id");
        }
    }
}
