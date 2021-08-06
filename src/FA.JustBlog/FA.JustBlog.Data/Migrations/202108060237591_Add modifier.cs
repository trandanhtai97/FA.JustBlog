namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmodifier : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Posts", newSchema: "common");
            CreateTable(
                "common.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        CommentHeader = c.String(),
                        CommentText = c.String(),
                        CommentTime = c.DateTime(nullable: false),
                        PostId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        InsertedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("common.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            AddColumn("common.Posts", "ImageUrl", c => c.String(maxLength: 255));
            AddColumn("common.Posts", "PublishedDate", c => c.DateTime(nullable: false));
            AddColumn("common.Posts", "ViewCount", c => c.Int(nullable: false));
            AddColumn("common.Posts", "RateCount", c => c.Int(nullable: false));
            AddColumn("common.Posts", "TotalRate", c => c.Int(nullable: false));
            DropColumn("common.Posts", "PostedOn");
        }
        
        public override void Down()
        {
            AddColumn("common.Posts", "PostedOn", c => c.DateTime(nullable: false));
            DropForeignKey("common.Comments", "PostId", "common.Posts");
            DropIndex("common.Comments", new[] { "PostId" });
            DropColumn("common.Posts", "TotalRate");
            DropColumn("common.Posts", "RateCount");
            DropColumn("common.Posts", "ViewCount");
            DropColumn("common.Posts", "PublishedDate");
            DropColumn("common.Posts", "ImageUrl");
            DropTable("common.Comments");
            MoveTable(name: "common.Posts", newSchema: "dbo");
        }
    }
}
