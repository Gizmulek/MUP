namespace MeetUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminmessage3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "AdminMessage_Id", "dbo.AdminMessages");
            DropIndex("dbo.Messages", new[] { "AdminMessage_Id" });
            DropColumn("dbo.Messages", "AdminMessage_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "AdminMessage_Id", c => c.Int());
            CreateIndex("dbo.Messages", "AdminMessage_Id");
            AddForeignKey("dbo.Messages", "AdminMessage_Id", "dbo.AdminMessages", "Id");
        }
    }
}
