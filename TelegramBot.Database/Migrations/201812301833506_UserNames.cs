namespace TelegramBot.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IncomeMessages", "FullName", c => c.String());
            AddColumn("dbo.IncomeMessages", "FirstName", c => c.String());
            AddColumn("dbo.IncomeMessages", "LastName", c => c.String());
            AddColumn("dbo.Messages", "FullName", c => c.String());
            AddColumn("dbo.Messages", "FirstName", c => c.String());
            AddColumn("dbo.Messages", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "LastName");
            DropColumn("dbo.Messages", "FirstName");
            DropColumn("dbo.Messages", "FullName");
            DropColumn("dbo.IncomeMessages", "LastName");
            DropColumn("dbo.IncomeMessages", "FirstName");
            DropColumn("dbo.IncomeMessages", "FullName");
        }
    }
}
