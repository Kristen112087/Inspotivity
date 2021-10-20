namespace Inspotivity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tookoutenum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PaperPattern", "PatternFor");
            DropColumn("dbo.PaperPattern", "DifficultyLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaperPattern", "DifficultyLevel", c => c.Int(nullable: false));
            AddColumn("dbo.PaperPattern", "PatternFor", c => c.Int(nullable: false));
        }
    }
}
