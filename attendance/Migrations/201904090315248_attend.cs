namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attend : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.faculties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        code = c.String(),
                        remarks = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        phone = c.String(),
                        email = c.String(),
                        facultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.faculties", t => t.facultyId, cascadeDelete: true)
                .Index(t => t.facultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.students", "facultyId", "dbo.faculties");
            DropIndex("dbo.students", new[] { "facultyId" });
            DropTable("dbo.students");
            DropTable("dbo.faculties");
        }
    }
}
