namespace eShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namenuevasEntidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Country = c.String(),
                        Province = c.String(),
                        Location = c.String(),
                        Street = c.String(),
                        Street2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                        Client_Id = c.String(maxLength: 128),
                        Product_Id = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        NetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Client_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Product_Id = c.Int(nullable: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ShippingAddress_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Available", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Orders", "ShippingAddress_Id");
            AddForeignKey("dbo.Orders", "ShippingAddress_Id", "dbo.Addresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShippingAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Documents", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Carts", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ShippingAddress_Id" });
            DropIndex("dbo.Documents", new[] { "Product_ProductId" });
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            DropIndex("dbo.Carts", new[] { "Client_Id" });
            DropColumn("dbo.Products", "Available");
            DropColumn("dbo.Orders", "ShippingAddress_Id");
            DropColumn("dbo.Orders", "Status");
            DropTable("dbo.Documents");
            DropTable("dbo.Carts");
            DropTable("dbo.Addresses");
        }
    }
}
