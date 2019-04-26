namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.teachers", "phoneNo", c => c.String());
            AddColumn("dbo.teachers", "hour", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.teachers", "hour");
            DropColumn("dbo.teachers", "phoneNo");
        }
    }
}
