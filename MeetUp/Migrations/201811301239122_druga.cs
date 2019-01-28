namespace MeetUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class druga : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "name");
        }
    }
}
