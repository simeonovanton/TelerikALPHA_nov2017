namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstUserId = c.Int(nullable: false),
                        SecondUserId = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        FriendsSince = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.FirstUserId)
                .ForeignKey("dbo.UserProfiles", t => t.SecondUserId)
                .Index(t => t.FirstUserId)
                .Index(t => t.SecondUserId)
                .Index(t => t.Approved);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        RegisteredOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        FileExtension = c.String(nullable: false, maxLength: 4),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FriendshipId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        SentOn = c.DateTime(nullable: false),
                        SeenOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.AuthorId)
                .ForeignKey("dbo.Friendships", t => t.FriendshipId)
                .Index(t => t.FriendshipId)
                .Index(t => t.AuthorId)
                .Index(t => t.SentOn);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfilePosts",
                c => new
                    {
                        UserProfile_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserProfile_Id, t.Post_Id })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "SecondUserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Friendships", "FirstUserId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfilePosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.UserProfilePosts", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Messages", "FriendshipId", "dbo.Friendships");
            DropForeignKey("dbo.Messages", "AuthorId", "dbo.UserProfiles");
            DropForeignKey("dbo.Images", "UserId", "dbo.UserProfiles");
            DropIndex("dbo.UserProfilePosts", new[] { "Post_Id" });
            DropIndex("dbo.UserProfilePosts", new[] { "UserProfile_Id" });
            DropIndex("dbo.Messages", new[] { "SentOn" });
            DropIndex("dbo.Messages", new[] { "AuthorId" });
            DropIndex("dbo.Messages", new[] { "FriendshipId" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropIndex("dbo.UserProfiles", new[] { "Username" });
            DropIndex("dbo.Friendships", new[] { "Approved" });
            DropIndex("dbo.Friendships", new[] { "SecondUserId" });
            DropIndex("dbo.Friendships", new[] { "FirstUserId" });
            DropTable("dbo.UserProfilePosts");
            DropTable("dbo.Posts");
            DropTable("dbo.Messages");
            DropTable("dbo.Images");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Friendships");
        }
    }
}
