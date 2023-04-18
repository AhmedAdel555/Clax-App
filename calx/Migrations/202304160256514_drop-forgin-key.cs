namespace calx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropforginkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Cars", "ApplicationUserId");
            DropColumn("dbo.Cars", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Cars", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "ApplicationUser_Id");
            AddForeignKey("dbo.Cars", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
