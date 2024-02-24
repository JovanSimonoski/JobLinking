namespace JobLinking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_UserRelationModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Logo = c.String(),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobAdvertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        City = c.String(),
                        JobId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobSeekers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Age = c.Int(nullable: false),
                        City = c.String(),
                        EducationLevel = c.String(),
                        Education = c.String(),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobSeekerJobAdvertisements",
                c => new
                    {
                        JobSeeker_Id = c.Int(nullable: false),
                        JobAdvertisement_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobSeeker_Id, t.JobAdvertisement_Id })
                .ForeignKey("dbo.JobSeekers", t => t.JobSeeker_Id, cascadeDelete: true)
                .ForeignKey("dbo.JobAdvertisements", t => t.JobAdvertisement_Id, cascadeDelete: true)
                .Index(t => t.JobSeeker_Id)
                .Index(t => t.JobAdvertisement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobSeekerJobAdvertisements", "JobAdvertisement_Id", "dbo.JobAdvertisements");
            DropForeignKey("dbo.JobSeekerJobAdvertisements", "JobSeeker_Id", "dbo.JobSeekers");
            DropForeignKey("dbo.JobAdvertisements", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.JobAdvertisements", "CompanyId", "dbo.Companies");
            DropIndex("dbo.JobSeekerJobAdvertisements", new[] { "JobAdvertisement_Id" });
            DropIndex("dbo.JobSeekerJobAdvertisements", new[] { "JobSeeker_Id" });
            DropIndex("dbo.JobAdvertisements", new[] { "CompanyId" });
            DropIndex("dbo.JobAdvertisements", new[] { "JobId" });
            DropTable("dbo.JobSeekerJobAdvertisements");
            DropTable("dbo.JobSeekers");
            DropTable("dbo.Jobs");
            DropTable("dbo.JobAdvertisements");
            DropTable("dbo.Companies");
        }
    }
}
