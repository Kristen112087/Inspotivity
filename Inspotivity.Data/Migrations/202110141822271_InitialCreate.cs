namespace Inspotivity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabric",
                c => new
                    {
                        FabricId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FabricType = c.String(),
                        FiberContent = c.String(),
                        WeightPerYard = c.Double(nullable: false),
                        DatePurchased = c.DateTimeOffset(nullable: false, precision: 7),
                        PricePerYard = c.Double(nullable: false),
                        StretchPercentage = c.Int(nullable: false),
                        YardsOnHand = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FabricId);
            
            CreateTable(
                "dbo.Make",
                c => new
                    {
                        MakeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PaperPatternId = c.Int(nullable: false),
                        FabricId = c.Int(nullable: false),
                        MeasurementsId = c.Int(nullable: false),
                        SizeMade = c.String(),
                        Notes = c.String(),
                        DateMade = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.MakeId)
                .ForeignKey("dbo.Fabric", t => t.FabricId, cascadeDelete: true)
                .ForeignKey("dbo.Measurements", t => t.MeasurementsId, cascadeDelete: true)
                .ForeignKey("dbo.PaperPattern", t => t.PaperPatternId, cascadeDelete: true)
                .Index(t => t.PaperPatternId)
                .Index(t => t.FabricId)
                .Index(t => t.MeasurementsId);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        MeasurementsId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Who = c.String(nullable: false),
                        Height = c.Double(nullable: false),
                        HeadCircumference = c.Double(nullable: false),
                        UpperBust = c.Double(nullable: false),
                        FullBust = c.Double(nullable: false),
                        UnderBust = c.Double(nullable: false),
                        Waist = c.Double(nullable: false),
                        Hips = c.Double(nullable: false),
                        OneThigh = c.Double(nullable: false),
                        OneCalf = c.Double(nullable: false),
                        OneUpperArm = c.Double(nullable: false),
                        OneLowerArm = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MeasurementsId);
            
            CreateTable(
                "dbo.PaperPattern",
                c => new
                    {
                        PaperPatternId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Designer = c.String(),
                        PatternName = c.String(),
                        ReleaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PurchaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PatternURL = c.String(),
                        PatternNumber = c.String(),
                        Category = c.String(),
                        FabricTypeNeeded = c.String(),
                        FabricRequirementInYards = c.Double(nullable: false),
                        NotionsNeeded = c.String(),
                        PatternFor = c.Int(nullable: false),
                        DifficultyLevel = c.Int(nullable: false),
                        WhereStored = c.String(),
                        HaveMade = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PaperPatternId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Make", "PaperPatternId", "dbo.PaperPattern");
            DropForeignKey("dbo.Make", "MeasurementsId", "dbo.Measurements");
            DropForeignKey("dbo.Make", "FabricId", "dbo.Fabric");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Make", new[] { "MeasurementsId" });
            DropIndex("dbo.Make", new[] { "FabricId" });
            DropIndex("dbo.Make", new[] { "PaperPatternId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PaperPattern");
            DropTable("dbo.Measurements");
            DropTable("dbo.Make");
            DropTable("dbo.Fabric");
        }
    }
}
