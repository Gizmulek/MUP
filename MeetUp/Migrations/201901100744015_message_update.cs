namespace MeetUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "User_userId", c => c.Int());
            CreateIndex("dbo.Users", "User_userId");
            AddForeignKey("dbo.Users", "User_userId", "dbo.Users", "userId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "User_userId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_userId" });
            DropColumn("dbo.Users", "User_userId");
        }
    }
}
