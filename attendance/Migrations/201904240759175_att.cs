namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class att : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.students", "facultyId", "dbo.faculties");
            DropIndex("dbo.students", new[] { "facultyId" });
            CreateTable(
                "dbo.attendanceModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        remarks = c.String(),
                        date = c.String(),
                        status = c.String(),
                        studentId = c.Int(),
                        timeTableId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.students", t => t.studentId)
                .ForeignKey("dbo.timeTables", t => t.timeTableId)
                .Index(t => t.studentId)
                .Index(t => t.timeTableId);
            
            CreateTable(
                "dbo.timeTables",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        teacherId = c.Int(nullable: false),
                        courseId = c.Int(nullable: false),
                        startTime = c.String(),
                        endTime = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.courses", t => t.courseId, cascadeDelete: true)
                .ForeignKey("dbo.teachers", t => t.teacherId, cascadeDelete: true)
                .Index(t => t.teacherId)
                .Index(t => t.courseId);
            
            CreateTable(
                "dbo.courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        code = c.String(),
                        creditHour = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.teachers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        position = c.String(),
                        courseId = c.Int(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.courses", t => t.courseId)
                .Index(t => t.courseId);
            
            CreateTable(
                "dbo.facultyCourses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        courseId = c.Int(nullable: false),
                        facultyId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.courses", t => t.courseId, cascadeDelete: true)
                .ForeignKey("dbo.faculties", t => t.facultyId)
                .Index(t => t.courseId)
                .Index(t => t.facultyId);
            
            AddColumn("dbo.faculties", "yearLong", c => c.String());
            AddColumn("dbo.students", "DOB", c => c.String());
            AddColumn("dbo.students", "address", c => c.String());
            AddColumn("dbo.students", "groupId", c => c.String());
            AlterColumn("dbo.students", "facultyId", c => c.Int());
            CreateIndex("dbo.students", "facultyId");
            AddForeignKey("dbo.students", "facultyId", "dbo.faculties", "id");
            DropColumn("dbo.faculties", "remarks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.faculties", "remarks", c => c.String());
            DropForeignKey("dbo.students", "facultyId", "dbo.faculties");
            DropForeignKey("dbo.facultyCourses", "facultyId", "dbo.faculties");
            DropForeignKey("dbo.facultyCourses", "courseId", "dbo.courses");
            DropForeignKey("dbo.attendanceModels", "timeTableId", "dbo.timeTables");
            DropForeignKey("dbo.timeTables", "teacherId", "dbo.teachers");
            DropForeignKey("dbo.teachers", "courseId", "dbo.courses");
            DropForeignKey("dbo.timeTables", "courseId", "dbo.courses");
            DropForeignKey("dbo.attendanceModels", "studentId", "dbo.students");
            DropIndex("dbo.facultyCourses", new[] { "facultyId" });
            DropIndex("dbo.facultyCourses", new[] { "courseId" });
            DropIndex("dbo.teachers", new[] { "courseId" });
            DropIndex("dbo.timeTables", new[] { "courseId" });
            DropIndex("dbo.timeTables", new[] { "teacherId" });
            DropIndex("dbo.students", new[] { "facultyId" });
            DropIndex("dbo.attendanceModels", new[] { "timeTableId" });
            DropIndex("dbo.attendanceModels", new[] { "studentId" });
            AlterColumn("dbo.students", "facultyId", c => c.Int(nullable: false));
            DropColumn("dbo.students", "groupId");
            DropColumn("dbo.students", "address");
            DropColumn("dbo.students", "DOB");
            DropColumn("dbo.faculties", "yearLong");
            DropTable("dbo.facultyCourses");
            DropTable("dbo.teachers");
            DropTable("dbo.courses");
            DropTable("dbo.timeTables");
            DropTable("dbo.attendanceModels");
            CreateIndex("dbo.students", "facultyId");
            AddForeignKey("dbo.students", "facultyId", "dbo.faculties", "id", cascadeDelete: true);
        }
    }
}
