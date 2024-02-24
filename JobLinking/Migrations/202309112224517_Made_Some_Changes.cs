namespace JobLinking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Made_Some_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobSeekers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobSeekers", "Image");
        }
    }
}
