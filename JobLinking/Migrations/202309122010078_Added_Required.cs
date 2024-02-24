namespace JobLinking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "Logo", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "About", c => c.String(nullable: false));
            AlterColumn("dbo.JobAdvertisements", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.JobAdvertisements", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Jobs", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.JobSeekers", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.JobSeekers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.JobSeekers", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.JobSeekers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.JobSeekers", "EducationLevel", c => c.String(nullable: false));
            AlterColumn("dbo.JobSeekers", "Education", c => c.String(nullable: false));
            AlterColumn("dbo.JobSeekers", "About", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobSeekers", "About", c => c.String());
            AlterColumn("dbo.JobSeekers", "Education", c => c.String());
            AlterColumn("dbo.JobSeekers", "EducationLevel", c => c.String());
            AlterColumn("dbo.JobSeekers", "City", c => c.String());
            AlterColumn("dbo.JobSeekers", "Surname", c => c.String());
            AlterColumn("dbo.JobSeekers", "Name", c => c.String());
            AlterColumn("dbo.JobSeekers", "Image", c => c.String());
            AlterColumn("dbo.Jobs", "Title", c => c.String());
            AlterColumn("dbo.JobAdvertisements", "City", c => c.String());
            AlterColumn("dbo.JobAdvertisements", "Description", c => c.String());
            AlterColumn("dbo.Companies", "About", c => c.String());
            AlterColumn("dbo.Companies", "Logo", c => c.String());
            AlterColumn("dbo.Companies", "City", c => c.String());
            AlterColumn("dbo.Companies", "Name", c => c.String());
        }
    }
}
