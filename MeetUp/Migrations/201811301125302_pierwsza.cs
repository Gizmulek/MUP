namespace MeetUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pierwsza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        number = c.Int(nullable: false),
                        palce = c.String(nullable: false, maxLength: 20),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        password = c.String(nullable: false, maxLength: 20),
                        confirmedpassword = c.String(),
                        surname = c.String(),
                        age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Newsletters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Stands",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        stand_type = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stands", "Id", "dbo.Events");
            DropForeignKey("dbo.Newsletters", "Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Id", "dbo.Users");
            DropForeignKey("dbo.Events", "Id", "dbo.Users");
            DropIndex("dbo.Stands", new[] { "Id" });
            DropIndex("dbo.Newsletters", new[] { "Id" });
            DropIndex("dbo.Messages", new[] { "Id" });
            DropIndex("dbo.Events", new[] { "Id" });
            DropTable("dbo.Stands");
            DropTable("dbo.Newsletters");
            DropTable("dbo.Messages");
            DropTable("dbo.Users");
            DropTable("dbo.Events");
        }
    }
}
