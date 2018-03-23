namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedSomeRequredOnSender : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PostUserProfiles", newName: "UserProfilePosts");
            DropForeignKey("dbo.Messages", "Author_UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Messages", new[] { "Author_UserProfileId" });
            DropPrimaryKey("dbo.UserProfilePosts");
            AlterColumn("dbo.Friendships", "FriendsSince", c => c.DateTime());
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "SeenOn", c => c.DateTime());
            AlterColumn("dbo.Messages", "Author_UserProfileId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserProfiles", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.UserProfiles", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.UserProfiles", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Images", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Images", "FileExtension", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
            AddPrimaryKey("dbo.UserProfilePosts", new[] { "UserProfile_UserProfileId", "Post_PostId" });
            CreateIndex("dbo.Messages", "Author_UserProfileId");
            CreateIndex("dbo.UserProfiles", "Username", unique: true, name: "Index");
            AddForeignKey("dbo.Messages", "Author_UserProfileId", "dbo.UserProfiles", "UserProfileId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Author_UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.UserProfiles", "Index");
            DropIndex("dbo.Messages", new[] { "Author_UserProfileId" });
            DropPrimaryKey("dbo.UserProfilePosts");
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Images", "FileExtension", c => c.String());
            AlterColumn("dbo.Images", "ImageUrl", c => c.String());
            AlterColumn("dbo.UserProfiles", "LastName", c => c.String());
            AlterColumn("dbo.UserProfiles", "FirstName", c => c.String());
            AlterColumn("dbo.UserProfiles", "Username", c => c.String());
            AlterColumn("dbo.Messages", "Author_UserProfileId", c => c.Int());
            AlterColumn("dbo.Messages", "SeenOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Messages", "Content", c => c.String());
            AlterColumn("dbo.Friendships", "FriendsSince", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.UserProfilePosts", new[] { "Post_PostId", "UserProfile_UserProfileId" });
            CreateIndex("dbo.Messages", "Author_UserProfileId");
            AddForeignKey("dbo.Messages", "Author_UserProfileId", "dbo.UserProfiles", "UserProfileId");
            RenameTable(name: "dbo.UserProfilePosts", newName: "PostUserProfiles");
        }
    }
}
