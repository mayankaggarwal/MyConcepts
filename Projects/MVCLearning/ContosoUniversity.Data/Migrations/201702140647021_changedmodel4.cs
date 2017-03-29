namespace ContosoUniversity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodel4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Course", "Title", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Course", "Title", c => c.String());
        }
    }
}
