namespace TableTennisChampionshipData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvanceGroupCriterias",
                c => new
                    {
                        AdvanceGroupCriteriaID = c.Int(nullable: false, identity: true),
                        AdvanceGroupCriteriaDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdvanceGroupCriteriaID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameNumber = c.Int(nullable: false),
                        PointsWin = c.Int(nullable: false),
                        PoinsLost = c.Int(nullable: false),
                        PlayerWon = c.Int(nullable: false),
                        Playerlost = c.Int(nullable: false),
                        LostPlayer_PlayerID = c.Int(),
                        WonPlayer_PlayerID = c.Int(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Players", t => t.LostPlayer_PlayerID)
                .ForeignKey("dbo.Players", t => t.WonPlayer_PlayerID)
                .Index(t => t.LostPlayer_PlayerID)
                .Index(t => t.WonPlayer_PlayerID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhotoFile = c.String(),
                        Age = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchID = c.Int(nullable: false, identity: true),
                        MatchName = c.String(nullable: false),
                        PLayerWonPoints = c.Int(nullable: false),
                        PlayerLostPoints = c.Int(nullable: false),
                        PlayerWon = c.Int(nullable: false),
                        PlayerLost = c.Int(nullable: false),
                        TournamentID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        LostPlayer_PlayerID = c.Int(),
                        WonPlayer_PlayerID = c.Int(),
                    })
                .PrimaryKey(t => t.MatchID)
                .ForeignKey("dbo.Players", t => t.LostPlayer_PlayerID)
                .ForeignKey("dbo.Stages", t => t.StageID, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.TournamentID, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.WonPlayer_PlayerID)
                .Index(t => t.LostPlayer_PlayerID)
                .Index(t => t.StageID)
                .Index(t => t.TournamentID)
                .Index(t => t.WonPlayer_PlayerID);
            
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        StageID = c.Int(nullable: false, identity: true),
                        StateName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StageID);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        FirstPlacePlayerID = c.Int(nullable: false),
                        SecondPlacePlayerID = c.Int(nullable: false),
                        ThirdPlacePlayerID = c.Int(nullable: false),
                        TournamentTypeID = c.Int(nullable: false),
                        AdvanceGroupCriteriaID = c.Int(nullable: false),
                        FirstPlacePlayer_PlayerID = c.Int(),
                        SecondPlacePlayer_PlayerID = c.Int(),
                        ThirdPlacePlayer_PlayerID = c.Int(),
                    })
                .PrimaryKey(t => t.TournamentID)
                .ForeignKey("dbo.AdvanceGroupCriterias", t => t.AdvanceGroupCriteriaID, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.FirstPlacePlayer_PlayerID)
                .ForeignKey("dbo.Players", t => t.SecondPlacePlayer_PlayerID)
                .ForeignKey("dbo.Players", t => t.ThirdPlacePlayer_PlayerID)
                .ForeignKey("dbo.TournamentTypes", t => t.TournamentTypeID, cascadeDelete: true)
                .Index(t => t.AdvanceGroupCriteriaID)
                .Index(t => t.FirstPlacePlayer_PlayerID)
                .Index(t => t.SecondPlacePlayer_PlayerID)
                .Index(t => t.ThirdPlacePlayer_PlayerID)
                .Index(t => t.TournamentTypeID);
            
            CreateTable(
                "dbo.TournamentTypes",
                c => new
                    {
                        TournamentTypeID = c.Int(nullable: false, identity: true),
                        TournamentTypeName = c.String(),
                    })
                .PrimaryKey(t => t.TournamentTypeID);
            
            CreateTable(
                "dbo.MatchRules",
                c => new
                    {
                        MatchRuleID = c.Int(nullable: false, identity: true),
                        PointsPerGame = c.Int(nullable: false),
                        ThreePoints = c.String(nullable: false),
                        TwoPoints = c.String(nullable: false),
                        OnePoint = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MatchRuleID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matches", "WonPlayer_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Matches", "TournamentID", "dbo.Tournaments");
            DropForeignKey("dbo.Tournaments", "TournamentTypeID", "dbo.TournamentTypes");
            DropForeignKey("dbo.Tournaments", "ThirdPlacePlayer_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Tournaments", "SecondPlacePlayer_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Tournaments", "FirstPlacePlayer_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Tournaments", "AdvanceGroupCriteriaID", "dbo.AdvanceGroupCriterias");
            DropForeignKey("dbo.Matches", "StageID", "dbo.Stages");
            DropForeignKey("dbo.Matches", "LostPlayer_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "WonPlayer_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Games", "LostPlayer_PlayerID", "dbo.Players");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Matches", new[] { "WonPlayer_PlayerID" });
            DropIndex("dbo.Matches", new[] { "TournamentID" });
            DropIndex("dbo.Tournaments", new[] { "TournamentTypeID" });
            DropIndex("dbo.Tournaments", new[] { "ThirdPlacePlayer_PlayerID" });
            DropIndex("dbo.Tournaments", new[] { "SecondPlacePlayer_PlayerID" });
            DropIndex("dbo.Tournaments", new[] { "FirstPlacePlayer_PlayerID" });
            DropIndex("dbo.Tournaments", new[] { "AdvanceGroupCriteriaID" });
            DropIndex("dbo.Matches", new[] { "StageID" });
            DropIndex("dbo.Matches", new[] { "LostPlayer_PlayerID" });
            DropIndex("dbo.Games", new[] { "WonPlayer_PlayerID" });
            DropIndex("dbo.Games", new[] { "LostPlayer_PlayerID" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MatchRules");
            DropTable("dbo.TournamentTypes");
            DropTable("dbo.Tournaments");
            DropTable("dbo.Stages");
            DropTable("dbo.Matches");
            DropTable("dbo.Players");
            DropTable("dbo.Games");
            DropTable("dbo.AdvanceGroupCriterias");
        }
    }
}
