namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.students", "StudentName", c => c.String(nullable: false));
            DropColumn("dbo.students", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.students", "name", c => c.String(nullable: false));
            DropColumn("dbo.students", "StudentName");
        }
    }
}
