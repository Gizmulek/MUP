namespace MeetUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reborn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stands", "Id", "dbo.Events");
            DropIndex("dbo.Events", new[] { "userID" });
            DropIndex("dbo.Stands", new[] { "Id" });
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Stands");
            AddColumn("dbo.Events", "Event_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Newsletters", "userID", c => c.Int(nullable: false));
            AddColumn("dbo.Stands", "EventId", c => c.Int(nullable: false));
            AlterColumn("dbo.Stands", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Events", "Event_Id");
            AddPrimaryKey("dbo.Stands", "Id");
            CreateIndex("dbo.Events", "userId");
            CreateIndex("dbo.Stands", "EventId");
            AddForeignKey("dbo.Stands", "EventId", "dbo.Events", "Event_Id", cascadeDelete: true);
            DropColumn("dbo.Events", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Stands", "EventId", "dbo.Events");
            DropIndex("dbo.Stands", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "userId" });
            DropPrimaryKey("dbo.Stands");
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Stands", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Stands", "EventId");
            DropColumn("dbo.Newsletters", "userID");
            DropColumn("dbo.Events", "Event_Id");
            AddPrimaryKey("dbo.Stands", "Id");
            AddPrimaryKey("dbo.Events", "Id");
            CreateIndex("dbo.Stands", "Id");
            CreateIndex("dbo.Events", "userID");
            AddForeignKey("dbo.Stands", "Id", "dbo.Events", "Id");
        }
    }
}
