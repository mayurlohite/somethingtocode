namespace SomethingToCode.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDEDCATEGORYPHOTO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryImage", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryImage");
        }
    }
}
