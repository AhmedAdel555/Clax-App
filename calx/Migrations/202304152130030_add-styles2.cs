namespace calx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstyles2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CarStyles (Name) VALUES ('Sedan')");
            Sql("INSERT INTO CarStyles (Name) VALUES ('Hatchback')");
        }
        
        public override void Down()
        {
        }
    }
}
