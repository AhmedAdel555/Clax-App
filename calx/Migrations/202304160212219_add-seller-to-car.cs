namespace calx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsellertocar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cars", "ApplicationUser_Id");
            AddForeignKey("dbo.Cars", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Cars", "ApplicationUser_Id");
            DropColumn("dbo.Cars", "ApplicationUserId");
        }
    }
}
