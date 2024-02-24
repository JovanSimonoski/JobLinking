namespace JobLinking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_UserIdRelation_In_JobSeekerAndCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "UserIdRelation", c => c.String());
            AddColumn("dbo.JobSeekers", "UserIdRelation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobSeekers", "UserIdRelation");
            DropColumn("dbo.Companies", "UserIdRelation");
        }
    }
}
