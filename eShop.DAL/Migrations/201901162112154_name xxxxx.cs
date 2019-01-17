namespace eShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namexxxxx : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Carts", name: "ProductId", newName: "Product_Id");
            RenameIndex(table: "dbo.Carts", name: "IX_ProductId", newName: "IX_Product_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Carts", name: "IX_Product_Id", newName: "IX_ProductId");
            RenameColumn(table: "dbo.Carts", name: "Product_Id", newName: "ProductId");
        }
    }
}
