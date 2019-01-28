namespace MeetUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminmessage10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminMessages", "userID", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "userID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "userID");
            DropColumn("dbo.AdminMessages", "userID");
        }
    }
}
