namespace Inspotivity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedVariableTypeFromIntToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fabric", "StretchPercentage", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fabric", "StretchPercentage", c => c.Int(nullable: false));
        }
    }
}
