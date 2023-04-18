namespace calx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makepricedoubleaftermistak : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Year", c => c.Double(nullable: false));
        }
    }
}
