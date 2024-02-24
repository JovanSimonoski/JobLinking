namespace JobLinking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_UserRelationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCompanyRelationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserJobSeekerRelationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        JobSeekerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserJobSeekerRelationModels");
            DropTable("dbo.UserCompanyRelationModels");
        }
    }
}
