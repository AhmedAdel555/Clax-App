namespace calx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Make", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Cars", "Model", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Cars", "Color", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Make", c => c.String(nullable: false));
        }
    }
}
