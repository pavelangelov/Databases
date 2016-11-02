namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Homework", "CourseId");
            AddForeignKey("dbo.Homework", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homework", "CourseId", "dbo.Courses");
            DropIndex("dbo.Homework", new[] { "CourseId" });
        }
    }
}
