namespace ContosoUniversity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Enrollments");
        }
    }
}
