namespace attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class group : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.timeTables", "GroupId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.timeTables", "GroupId", c => c.Int(nullable: false));
        }
    }
}
