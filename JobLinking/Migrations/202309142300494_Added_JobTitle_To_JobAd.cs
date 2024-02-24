namespace JobLinking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_JobTitle_To_JobAd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobAdvertisements", "JobTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobAdvertisements", "JobTitle");
        }
    }
}
