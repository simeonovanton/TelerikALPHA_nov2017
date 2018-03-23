namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAdditionalRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friendships", "UserProfile_UserProfileId", c => c.Int());
            AddColumn("dbo.Images", "UserId_UserProfileId", c => c.Int());
            AddColumn("dbo.Messages", "Friendship_FriendshipId", c => c.Int());
            CreateIndex("dbo.Friendships", "UserProfile_UserProfileId");
            CreateIndex("dbo.Messages", "Friendship_FriendshipId");
            CreateIndex("dbo.Images", "UserId_UserProfileId");
            AddForeignKey("dbo.Friendships", "UserProfile_UserProfileId", "dbo.UserProfiles", "UserProfileId");
            AddForeignKey("dbo.Images", "UserId_UserProfileId", "dbo.UserProfiles", "UserProfileId");
            AddForeignKey("dbo.Messages", "Friendship_FriendshipId", "dbo.Friendships", "FriendshipId");
            DropColumn("dbo.Images", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Messages", "Friendship_FriendshipId", "dbo.Friendships");
            DropForeignKey("dbo.Images", "UserId_UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Friendships", "UserProfile_UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Images", new[] { "UserId_UserProfileId" });
            DropIndex("dbo.Messages", new[] { "Friendship_FriendshipId" });
            DropIndex("dbo.Friendships", new[] { "UserProfile_UserProfileId" });
            DropColumn("dbo.Messages", "Friendship_FriendshipId");
            DropColumn("dbo.Images", "UserId_UserProfileId");
            DropColumn("dbo.Friendships", "UserProfile_UserProfileId");
        }
    }
}
