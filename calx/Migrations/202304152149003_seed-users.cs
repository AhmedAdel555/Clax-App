namespace calx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'88a9fa61-a20d-420d-8396-a7f4543b39f7', N'admin@clax.com', 0, N'AKKw+HxcItDsvU0hz100/LCvp9yY3ZgVaA8jP+wc1Hjci7mpN0TaJMV6yODFzKw+ag==', N'020cf85d-aaf5-473c-941a-7406e62bce8b', N'01020316997', 0, 0, NULL, 1, 0, N'admin@clax.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'36ecd7b0-d82e-4927-ac97-974a36964fed', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'88a9fa61-a20d-420d-8396-a7f4543b39f7', N'36ecd7b0-d82e-4927-ac97-974a36964fed')

");
        }
        
        public override void Down()
        {
        }
    }
}
