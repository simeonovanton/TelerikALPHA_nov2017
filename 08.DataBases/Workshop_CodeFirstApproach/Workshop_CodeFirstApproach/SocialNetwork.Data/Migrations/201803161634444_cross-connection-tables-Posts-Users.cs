namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crossconnectiontablesPostsUsers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PostUserProfiles", newName: "UserProfilePosts");
            DropPrimaryKey("dbo.UserProfilePosts");
            AddPrimaryKey("dbo.UserProfilePosts", new[] { "UserProfile_UserProfileId", "Post_PostId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserProfilePosts");
            AddPrimaryKey("dbo.UserProfilePosts", new[] { "Post_PostId", "UserProfile_UserProfileId" });
            RenameTable(name: "dbo.UserProfilePosts", newName: "PostUserProfiles");
        }
    }
}
