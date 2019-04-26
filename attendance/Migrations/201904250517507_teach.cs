namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.teachers", "TeacherName", c => c.String(nullable: false));
            DropColumn("dbo.teachers", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teachers", "name", c => c.String(nullable: false));
            DropColumn("dbo.teachers", "TeacherName");
        }
    }
}
