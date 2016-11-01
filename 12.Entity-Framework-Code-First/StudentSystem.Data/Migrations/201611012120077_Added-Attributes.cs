namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 40));
            AlterColumn("dbo.Courses", "Description", c => c.String(maxLength: 40));
            AlterColumn("dbo.Students", "Name", c => c.String(maxLength: 40));
            AlterColumn("dbo.Homework", "Content", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Homework", "Content", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
