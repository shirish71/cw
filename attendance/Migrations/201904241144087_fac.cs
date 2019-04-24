namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fac : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.facultyCourses", "facultyId", "dbo.faculties");
            DropIndex("dbo.facultyCourses", new[] { "facultyId" });
            AlterColumn("dbo.facultyCourses", "facultyId", c => c.Int(nullable: false));
            CreateIndex("dbo.facultyCourses", "facultyId");
            AddForeignKey("dbo.facultyCourses", "facultyId", "dbo.faculties", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.facultyCourses", "facultyId", "dbo.faculties");
            DropIndex("dbo.facultyCourses", new[] { "facultyId" });
            AlterColumn("dbo.facultyCourses", "facultyId", c => c.Int());
            CreateIndex("dbo.facultyCourses", "facultyId");
            AddForeignKey("dbo.facultyCourses", "facultyId", "dbo.faculties", "id");
        }
    }
}
