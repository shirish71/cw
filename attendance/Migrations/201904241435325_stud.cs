namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stud : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.students", "facultyId", "dbo.faculties");
            DropIndex("dbo.students", new[] { "facultyId" });
            AlterColumn("dbo.students", "facultyId", c => c.Int(nullable: false));
            CreateIndex("dbo.students", "facultyId");
            AddForeignKey("dbo.students", "facultyId", "dbo.faculties", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.students", "facultyId", "dbo.faculties");
            DropIndex("dbo.students", new[] { "facultyId" });
            AlterColumn("dbo.students", "facultyId", c => c.Int());
            CreateIndex("dbo.students", "facultyId");
            AddForeignKey("dbo.students", "facultyId", "dbo.faculties", "id");
        }
    }
}
