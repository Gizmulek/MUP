namespace MeetUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reborn2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Place", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Events", "palce");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "palce", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Events", "Place");
        }
    }
}
