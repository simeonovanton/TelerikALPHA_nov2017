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
                        FriendshipId = c.Int(nullable: false, identity: true),
                        ApprovedStatus = c.String(),
                        FriendsSince = c.DateTime(nullable: false),
                        Reciever_UserProfileId = c.Int(),
                        Sender_UserProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.FriendshipId)
                .ForeignKey("dbo.UserProfiles", t => t.Reciever_UserProfileId)
                .ForeignKey("dbo.UserProfiles", t => t.Sender_UserProfileId)
                .Index(t => t.Reciever_UserProfileId)
                .Index(t => t.Sender_UserProfileId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserProfileId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RegisteredOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserProfileId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        FileExtension = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        SentOn = c.DateTime(nullable: false),
                        SeenOn = c.DateTime(nullable: false),
                        Author_UserProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.UserProfiles", t => t.Author_UserProfileId)
                .Index(t => t.Author_UserProfileId);
            
            CreateTable(
                "dbo.PostUserProfiles",
                c => new
                    {
                        Post_PostId = c.Int(nullable: false),
                        UserProfile_UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_PostId, t.UserProfile_UserProfileId })
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_UserProfileId, cascadeDelete: true)
                .Index(t => t.Post_PostId)
                .Index(t => t.UserProfile_UserProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Author_UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Friendships", "Sender_UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Friendships", "Reciever_UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.PostUserProfiles", "UserProfile_UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.PostUserProfiles", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.PostUserProfiles", new[] { "UserProfile_UserProfileId" });
            DropIndex("dbo.PostUserProfiles", new[] { "Post_PostId" });
            DropIndex("dbo.Messages", new[] { "Author_UserProfileId" });
            DropIndex("dbo.Friendships", new[] { "Sender_UserProfileId" });
            DropIndex("dbo.Friendships", new[] { "Reciever_UserProfileId" });
            DropTable("dbo.PostUserProfiles");
            DropTable("dbo.Messages");
            DropTable("dbo.Images");
            DropTable("dbo.Posts");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Friendships");
        }
    }
}
