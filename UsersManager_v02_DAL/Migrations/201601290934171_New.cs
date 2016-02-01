namespace UsersManager_v02_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessMetadata",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(),
                        UpdatedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Profile", t => t.ProfileId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.User", t => t.UpdatedBy)
                .Index(t => t.UserId)
                .Index(t => t.DepartmentId)
                .Index(t => t.ProfileId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccessMetadata", "UpdatedBy", "dbo.User");
            DropForeignKey("dbo.AccessMetadata", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.AccessMetadata", "UserId", "dbo.User");
            DropForeignKey("dbo.AccessMetadata", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.AccessMetadata", "DepartmentId", "dbo.Department");
            DropIndex("dbo.AccessMetadata", new[] { "UpdatedBy" });
            DropIndex("dbo.AccessMetadata", new[] { "CreatedBy" });
            DropIndex("dbo.AccessMetadata", new[] { "ProfileId" });
            DropIndex("dbo.AccessMetadata", new[] { "DepartmentId" });
            DropIndex("dbo.AccessMetadata", new[] { "UserId" });
            DropTable("dbo.AccessMetadata");
        }
    }
}
