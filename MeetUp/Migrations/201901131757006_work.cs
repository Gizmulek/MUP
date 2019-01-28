namespace MeetUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class work : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminMessages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminMessages", "Id", "dbo.Users");
            DropIndex("dbo.AdminMessages", new[] { "Id" });
            DropTable("dbo.AdminMessages");
        }
    }
}
