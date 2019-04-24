namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class att : DbMigration
    {
        public override void Up()
        {
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
                "dbo.students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        phone = c.String(),
                        email = c.String(),
                        DOB = c.String(),
                        address = c.String(),
                        groupId = c.String(),
                        facultyId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.faculties", t => t.facultyId)
                .Index(t => t.facultyId);
            
            CreateTable(
                "dbo.faculties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        code = c.String(),
                        yearLong = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.facultyCourses", "facultyId", "dbo.faculties");
            DropForeignKey("dbo.facultyCourses", "courseId", "dbo.courses");
            DropForeignKey("dbo.attendanceModels", "timeTableId", "dbo.timeTables");
            DropForeignKey("dbo.timeTables", "teacherId", "dbo.teachers");
            DropForeignKey("dbo.teachers", "courseId", "dbo.courses");
            DropForeignKey("dbo.timeTables", "courseId", "dbo.courses");
            DropForeignKey("dbo.attendanceModels", "studentId", "dbo.students");
            DropForeignKey("dbo.students", "facultyId", "dbo.faculties");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.facultyCourses", new[] { "facultyId" });
            DropIndex("dbo.facultyCourses", new[] { "courseId" });
            DropIndex("dbo.teachers", new[] { "courseId" });
            DropIndex("dbo.timeTables", new[] { "courseId" });
            DropIndex("dbo.timeTables", new[] { "teacherId" });
            DropIndex("dbo.students", new[] { "facultyId" });
            DropIndex("dbo.attendanceModels", new[] { "timeTableId" });
            DropIndex("dbo.attendanceModels", new[] { "studentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.facultyCourses");
            DropTable("dbo.teachers");
            DropTable("dbo.courses");
            DropTable("dbo.timeTables");
            DropTable("dbo.faculties");
            DropTable("dbo.students");
            DropTable("dbo.attendanceModels");
        }
    }
}
