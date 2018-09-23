namespace TelegramBot.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncomeMessage = c.String(),
                        ReplyMessage = c.String(),
                        ChatId = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wallpapers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wallpapers");
            DropTable("dbo.Messages");
            DropTable("dbo.CatImages");
        }
    }
}
