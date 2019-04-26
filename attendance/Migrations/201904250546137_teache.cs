namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teache : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.teachers", "TeacherEmail", c => c.String());
            DropColumn("dbo.teachers", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teachers", "userId", c => c.Int(nullable: false));
            DropColumn("dbo.teachers", "TeacherEmail");
        }
    }
}
