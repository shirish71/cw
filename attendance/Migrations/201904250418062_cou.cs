namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cou : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.courses", "CourseName", c => c.String(nullable: false));
            DropColumn("dbo.courses", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.courses", "name", c => c.String(nullable: false));
            DropColumn("dbo.courses", "CourseName");
        }
    }
}
