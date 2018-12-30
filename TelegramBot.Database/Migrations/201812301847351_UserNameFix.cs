namespace TelegramBot.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IncomeMessages", "Username", c => c.String());
            AddColumn("dbo.Messages", "Username", c => c.String());
            DropColumn("dbo.IncomeMessages", "FullName");
            DropColumn("dbo.IncomeMessages", "FirstName");
            DropColumn("dbo.IncomeMessages", "LastName");
            DropColumn("dbo.Messages", "FullName");
            DropColumn("dbo.Messages", "FirstName");
            DropColumn("dbo.Messages", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "LastName", c => c.String());
            AddColumn("dbo.Messages", "FirstName", c => c.String());
            AddColumn("dbo.Messages", "FullName", c => c.String());
            AddColumn("dbo.IncomeMessages", "LastName", c => c.String());
            AddColumn("dbo.IncomeMessages", "FirstName", c => c.String());
            AddColumn("dbo.IncomeMessages", "FullName", c => c.String());
            DropColumn("dbo.Messages", "Username");
            DropColumn("dbo.IncomeMessages", "Username");
        }
    }
}
