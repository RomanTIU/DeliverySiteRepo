namespace DeliverySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiaCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.String(maxLength: 128),
                        ManufacturerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        DeliveryManId = c.Int(nullable: false),
                        SumCommand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ClientId)
                .ForeignKey("dbo.DeliveryMen", t => t.DeliveryManId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.ProductId)
                .Index(t => t.StatusId)
                .Index(t => t.DeliveryManId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.DeliveryMen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryManName = c.String(nullable: false),
                        ContactNumberDeliveryMan = c.Int(nullable: false),
                        EmailDeliveryMan = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(nullable: false),
                        AdressManufacturer = c.String(nullable: false),
                        ContactNumberManufacurer = c.Int(nullable: false),
                        EmailManufacturer = c.String(nullable: false),
                        ShereManufacturer = c.Int(nullable: false),
                        ImagePathLoggo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        TimeToReady = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        ImagePath = c.String(),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: false)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Commands", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Commands", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Commands", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Commands", "DeliveryManId", "dbo.DeliveryMen");
            DropForeignKey("dbo.Commands", "ClientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Commands", new[] { "DeliveryManId" });
            DropIndex("dbo.Commands", new[] { "StatusId" });
            DropIndex("dbo.Commands", new[] { "ProductId" });
            DropIndex("dbo.Commands", new[] { "ManufacturerId" });
            DropIndex("dbo.Commands", new[] { "ClientId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Status");
            DropTable("dbo.Products");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.DeliveryMen");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Commands");
        }
    }
}
