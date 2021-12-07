namespace menshakov08.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentOne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Students", "LastName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "Group", c => c.String(maxLength: 4));
            AlterColumn("dbo.Students", "Faculty", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "Specialty", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Specialty", c => c.String());
            AlterColumn("dbo.Students", "Faculty", c => c.String());
            AlterColumn("dbo.Students", "Group", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
        }
    }
}
