namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUserProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friendships", "UserProfile_UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Friendships", new[] { "UserProfile_UserProfileId" });
            DropColumn("dbo.Friendships", "UserProfile_UserProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Friendships", "UserProfile_UserProfileId", c => c.Int());
            CreateIndex("dbo.Friendships", "UserProfile_UserProfileId");
            AddForeignKey("dbo.Friendships", "UserProfile_UserProfileId", "dbo.UserProfiles", "UserProfileId");
        }
    }
}
