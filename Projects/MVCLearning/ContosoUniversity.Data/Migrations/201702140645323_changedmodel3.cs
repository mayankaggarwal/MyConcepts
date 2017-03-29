namespace ContosoUniversity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodel3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_Course");
        }
    }
}
