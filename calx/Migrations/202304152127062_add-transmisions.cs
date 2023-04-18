namespace calx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtransmisions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Transmissions (Name) VALUES ('Automatic')");
            Sql("INSERT INTO Transmissions (Name) VALUES ('manual')");
        }
        
        public override void Down()
        {
        }
    }
}
