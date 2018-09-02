namespace TelegramBot.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAdmin_BlackList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatId = c.Long(nullable: false),
                        Level = c.Int(nullable: false),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlackLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatId = c.Long(nullable: false),
                        MuteLevel = c.Int(nullable: false),
                        Comment = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        AdminId = c.Int(nullable: false),
                        AdminName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlackLists");
            DropTable("dbo.Admins");
        }
    }
}
