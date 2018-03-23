namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherOne2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserProfilePosts", newName: "PostUserProfiles");
            DropPrimaryKey("dbo.PostUserProfiles");
            AddPrimaryKey("dbo.PostUserProfiles", new[] { "Post_PostId", "UserProfile_UserProfileId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PostUserProfiles");
            AddPrimaryKey("dbo.PostUserProfiles", new[] { "UserProfile_UserProfileId", "Post_PostId" });
            RenameTable(name: "dbo.PostUserProfiles", newName: "UserProfilePosts");
        }
    }
}
