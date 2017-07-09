namespace SomethingToCode.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INITIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleComments",
                c => new
                    {
                        CommentID = c.Long(nullable: false, identity: true),
                        ArticleID = c.Long(nullable: false),
                        UserID = c.Long(nullable: false),
                        CommentDetails = c.String(),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.ArticleID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        ArticleTitle = c.String(nullable: false, maxLength: 155),
                        ShortDescription = c.String(nullable: false, maxLength: 255),
                        LongDescription = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        UrlSlug = c.String(nullable: false, maxLength: 155),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ArticleID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 155),
                        Description = c.String(nullable: false, maxLength: 255),
                        UrlSlug = c.String(nullable: false, maxLength: 155),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 70),
                        Role = c.String(maxLength: 20),
                        Website = c.String(maxLength: 100),
                        StatusMessage = c.String(maxLength: 255),
                        AboutMe = c.String(),
                        avtar = c.String(maxLength: 70),
                        IsEmailVerified = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        Hash = c.String(maxLength: 70),
                        Gender = c.String(maxLength: 10),
                        DateOfBirth = c.DateTime(),
                        IsSuperAdmin = c.Boolean(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        TagName = c.String(nullable: false, maxLength: 155),
                        Description = c.String(maxLength: 255),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.TagID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserAchivements",
                c => new
                    {
                        UserAchivementID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        Achivement = c.String(nullable: false, maxLength: 255),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserAchivementID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserEducations",
                c => new
                    {
                        UserEducationID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        SchoolName = c.String(nullable: false, maxLength: 255),
                        Degree = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Description = c.String(nullable: false, maxLength: 350),
                        Stilllearning = c.Boolean(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserEducationID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserSkills",
                c => new
                    {
                        UserSkillID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        SkillName = c.String(nullable: false, maxLength: 100),
                        SkillExpert = c.Decimal(nullable: false, precision: 5, scale: 2),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserSkillID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserWorks",
                c => new
                    {
                        UserWorkID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 255),
                        Designation = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Description = c.String(nullable: false, maxLength: 350),
                        StillWorking = c.Boolean(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserWorkID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.ExceptionLoggers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InnerException = c.String(maxLength: 255),
                        ExceptionMessage = c.String(maxLength: 255),
                        Source = c.String(maxLength: 100),
                        ExceptionStackTrace = c.String(),
                        ControllerName = c.String(maxLength: 100),
                        ActionName = c.String(maxLength: 60),
                        IsEnable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleCategories",
                c => new
                    {
                        ArticleID = c.Long(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleID, t.CategoryID })
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.ArticleID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ArticleTags",
                c => new
                    {
                        ArticleID = c.Long(nullable: false),
                        TagID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleID, t.TagID })
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ArticleID)
                .Index(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleComments", "UserID", "dbo.Users");
            DropForeignKey("dbo.ArticleComments", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Articles", "UserID", "dbo.Users");
            DropForeignKey("dbo.ArticleTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ArticleTags", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.ArticleCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.ArticleCategories", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Categories", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserWorks", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserSkills", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserEducations", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserAchivements", "UserID", "dbo.Users");
            DropForeignKey("dbo.Tags", "UserID", "dbo.Users");
            DropIndex("dbo.ArticleTags", new[] { "TagID" });
            DropIndex("dbo.ArticleTags", new[] { "ArticleID" });
            DropIndex("dbo.ArticleCategories", new[] { "CategoryID" });
            DropIndex("dbo.ArticleCategories", new[] { "ArticleID" });
            DropIndex("dbo.UserWorks", new[] { "UserID" });
            DropIndex("dbo.UserSkills", new[] { "UserID" });
            DropIndex("dbo.UserEducations", new[] { "UserID" });
            DropIndex("dbo.UserAchivements", new[] { "UserID" });
            DropIndex("dbo.Tags", new[] { "UserID" });
            DropIndex("dbo.Categories", new[] { "UserID" });
            DropIndex("dbo.Articles", new[] { "UserID" });
            DropIndex("dbo.ArticleComments", new[] { "UserID" });
            DropIndex("dbo.ArticleComments", new[] { "ArticleID" });
            DropTable("dbo.ArticleTags");
            DropTable("dbo.ArticleCategories");
            DropTable("dbo.ExceptionLoggers");
            DropTable("dbo.UserWorks");
            DropTable("dbo.UserSkills");
            DropTable("dbo.UserEducations");
            DropTable("dbo.UserAchivements");
            DropTable("dbo.Tags");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
            DropTable("dbo.ArticleComments");
        }
    }
}
