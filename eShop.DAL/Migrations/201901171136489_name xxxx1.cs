namespace eShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namexxxx1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderLines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Documents", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            DropIndex("dbo.Documents", new[] { "Product_ProductId" });
            DropIndex("dbo.OrderLines", new[] { "OrderId" });
            DropIndex("dbo.OrderLines", new[] { "ProductId" });
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Carts", "Product_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Documents", "Product_ProductId", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrderLines", "OrderId", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrderLines", "ProductId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "OrderId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Products", "ProductId");
            AddPrimaryKey("dbo.Orders", "OrderId");
            CreateIndex("dbo.Carts", "Product_Id");
            CreateIndex("dbo.Documents", "Product_ProductId");
            CreateIndex("dbo.OrderLines", "OrderId");
            CreateIndex("dbo.OrderLines", "ProductId");
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "ProductId");
            AddForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.OrderLines", "ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Documents", "Product_ProductId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderLines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderLines", new[] { "ProductId" });
            DropIndex("dbo.OrderLines", new[] { "OrderId" });
            DropIndex("dbo.Documents", new[] { "Product_ProductId" });
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OrderLines", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderLines", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Documents", "Product_ProductId", c => c.Int());
            AlterColumn("dbo.Products", "ProductId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Carts", "Product_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.Products", "ProductId");
            CreateIndex("dbo.OrderLines", "ProductId");
            CreateIndex("dbo.OrderLines", "OrderId");
            CreateIndex("dbo.Documents", "Product_ProductId");
            CreateIndex("dbo.Carts", "Product_Id");
            AddForeignKey("dbo.Documents", "Product_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.OrderLines", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
