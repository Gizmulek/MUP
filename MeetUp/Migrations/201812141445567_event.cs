namespace MeetUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _event : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Id", "dbo.Users");
            DropForeignKey("dbo.Stands", "Id", "dbo.Events");
            DropIndex("dbo.Events", new[] { "Id" });
            DropPrimaryKey("dbo.Events");
            AddColumn("dbo.Events", "userID", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Events", "Id");
            CreateIndex("dbo.Events", "userID");
            AddForeignKey("dbo.Events", "userID", "dbo.Users", "userId", cascadeDelete: true);
            AddForeignKey("dbo.Stands", "Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stands", "Id", "dbo.Events");
            DropForeignKey("dbo.Events", "userID", "dbo.Users");
            DropIndex("dbo.Events", new[] { "userID" });
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "userID");
            AddPrimaryKey("dbo.Events", "Id");
            CreateIndex("dbo.Events", "Id");
            AddForeignKey("dbo.Stands", "Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Events", "Id", "dbo.Users", "userId");
        }
    }
}
