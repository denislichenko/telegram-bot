namespace TelegramBot.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncomeMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncomeMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatId = c.Long(nullable: false),
                        Message = c.String(),
                        Answer = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IncomeMessages");
        }
    }
}
