namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Try : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUserRoles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUserRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
