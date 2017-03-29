namespace ContosoUniversity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodel5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tbl_Course", "DepartmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Course", "DepartmentID", c => c.Int(nullable: false));
        }
    }
}
