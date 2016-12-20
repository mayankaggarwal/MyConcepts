namespace IDW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_gir_identity",
                c => new
                    {
                        CUID = c.String(nullable: false, maxLength: 128),
                        Creation_Date = c.DateTime(),
                        Update_Date = c.DateTime(),
                        Description = c.String(),
                        Domain_Code = c.String(),
                        Directory_Sync = c.Boolean(),
                        Entry_Date = c.DateTime(),
                        Status = c.Boolean(),
                        Reporting_Global = c.Boolean(),
                        GASSI = c.Boolean(),
                        Lock_Identity = c.Boolean(),
                        First_Entry_Date = c.DateTime(),
                        VIP = c.Boolean(),
                        Last_Name = c.String(),
                        Subsidiary_Code = c.String(),
                        IsEnable = c.Boolean(),
                        Email = c.String(),
                        Local_Id = c.String(),
                        First_Name = c.String(),
                        Manager_CUID = c.String(),
                        Title = c.Short(),
                        Category_Code = c.String(),
                        Birth_Date = c.DateTime(),
                        Departure_Date = c.DateTime(),
                        Last_Departure_Date = c.DateTime(),
                        Preferred_First_Name = c.String(),
                        Preferred_Last_Name = c.String(),
                        Middle_Name = c.String(),
                        Alternate_Notification_Mail = c.String(),
                        Partner_Code = c.String(),
                        Sub_Employee_Type = c.String(),
                        Prefix = c.String(),
                    })
                .PrimaryKey(t => t.CUID);
            
            CreateTable(
                "dbo.tbl_pz_objecttag",
                c => new
                    {
                        ObjectID = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(),
                        ObjectTypeCode = c.Long(nullable: false),
                        ObjectType = c.String(),
                        TagID = c.Int(nullable: false),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.tbl_od_entity",
                c => new
                    {
                        Entity = c.String(nullable: false, maxLength: 128),
                        Sigle = c.String(),
                        Description = c.String(),
                        Other_Name = c.String(),
                        Type = c.String(),
                        URL = c.String(),
                        Mission = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Manager = c.String(),
                        Secondary_Manager = c.String(),
                        Secretary = c.String(),
                        RANK = c.Int(),
                        Email_Alias = c.String(),
                        Postal_Address = c.String(),
                        Location_Code = c.String(),
                        Last_Update_Date = c.DateTime(),
                        Creation_Date = c.DateTime(),
                        Subsidiary_Code = c.String(),
                        Entity_Comex = c.String(),
                        Entity_Country = c.String(),
                        Entity_Display_Name = c.String(),
                    })
                .PrimaryKey(t => t.Entity);
            
            CreateTable(
                "dbo.tbl_od_identity",
                c => new
                    {
                        CUID = c.String(nullable: false, maxLength: 128),
                        Title = c.Short(),
                        Last_Name = c.String(),
                        First_Name = c.String(),
                        Type_OD = c.String(),
                        Mobile = c.String(),
                        Phone_Number = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Secretary_CUID = c.String(),
                        Postal_Address = c.String(),
                        Location_Code = c.String(),
                        Entity = c.String(),
                        Manager_CUID = c.String(),
                        Category_Code = c.String(),
                        Mission = c.String(),
                        Function = c.String(),
                        Activity1 = c.String(),
                        Activity2 = c.String(),
                        Skill = c.String(),
                        Secondary_Entity = c.String(),
                        Secondary_Manager_CUID = c.String(),
                        Secondary_Secretary_CUID = c.String(),
                        Local_ID = c.String(),
                        Preferred_Language = c.String(),
                        Country_GIR = c.String(),
                        Country = c.String(),
                        Status = c.Short(),
                        Rank = c.String(),
                        Room_Number = c.String(),
                        Visiting_Card = c.String(),
                        Visiting_Card_FR = c.String(),
                        Visiting_Card_EN = c.String(),
                        Photo_Name = c.String(),
                        Last_Update_Date = c.DateTime(),
                        Creation_Date = c.DateTime(),
                        Other_Phone_Number = c.String(),
                        Email_Secondary = c.String(),
                        Display_Name = c.String(),
                        PKI = c.Boolean(),
                    })
                .PrimaryKey(t => t.CUID);
            
            CreateTable(
                "dbo.tbl_pz_blog",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(),
                        ModificationDate = c.DateTime(),
                        CMAuthentication = c.Short(),
                        FeedEnabled = c.Short(),
                        FeedFullContent = c.Short(),
                        ContainerID = c.Int(),
                        ContainerType = c.Long(),
                        ContainerCode = c.String(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.BlogID);
            
            CreateTable(
                "dbo.tbl_pz_community",
                c => new
                    {
                        CommunityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(),
                        ModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CommunityID);
            
            CreateTable(
                "dbo.tbl_pz_groupmember",
                c => new
                    {
                        GroupID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        MemberType = c.String(),
                        CreationDate = c.DateTime(),
                        MembershipID = c.Int(),
                        MemberDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.GroupID, t.UserID });
            
            CreateTable(
                "dbo.tbl_pz_userrelation",
                c => new
                    {
                        RelationshipID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        RelatedUserID = c.Int(),
                        RelnshipTypeID = c.Int(),
                        State = c.String(),
                        CreationDate = c.DateTime(),
                        RetirementDate = c.DateTime(),
                        ModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.RelationshipID);
            
            CreateTable(
                "dbo.tbl_pz_profile_his",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Modified = c.Boolean(),
                        Logged = c.Boolean(),
                        ProfileUpdated = c.Boolean(),
                        Points = c.Long(),
                        Department = c.String(),
                        Month_His = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.tbl_pz_project",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ParentTypeCode = c.Long(),
                        ParentType = c.String(),
                        ParentObjectID = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                        OwnerID = c.Int(),
                        CreationDate = c.DateTime(),
                        ModificationDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.tbl_Membership_Role",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_pz_socialgroup",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupType = c.String(),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Description = c.String(),
                        OwnerID = c.Int(),
                        CreationDate = c.DateTime(),
                        ModificationDate = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.tbl_pz_statuslevelpoint",
                c => new
                    {
                        PointID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        ContainerTypeCode = c.Long(),
                        ContainerType = c.String(),
                        ContainerID = c.Int(),
                        Points = c.Int(),
                        ObjectTypeCode = c.Long(),
                        ObjectType = c.String(),
                        ObjectID = c.Int(),
                        Code = c.String(),
                        CreationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PointID);
            
            CreateTable(
                "dbo.tbl_pz_activity",
                c => new
                    {
                        ActivityID = c.Long(nullable: false, identity: true),
                        ActivityType = c.String(),
                        ObjectTypeCode = c.Long(),
                        ObjectType = c.String(),
                        ObjectID = c.Int(),
                        ContainerTypeCode = c.Long(),
                        ContainerType = c.String(),
                        ContainerID = c.Int(),
                        UserID = c.Int(),
                        CreationDate = c.DateTime(),
                        CreationMonth = c.Short(),
                        CreationYear = c.Short(),
                    })
                .PrimaryKey(t => t.ActivityID);
            
            CreateTable(
                "dbo.tbl_pz_expertise",
                c => new
                    {
                        ExpertiseTagID = c.Int(nullable: false, identity: true),
                        TagID = c.Int(nullable: false),
                        TargetUserID = c.Int(nullable: false),
                        OriginUserID = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        ExpertiseCreationDate = c.DateTime(),
                        TagName = c.String(),
                        TagCreationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ExpertiseTagID);
            
            CreateTable(
                "dbo.tbl_pz_profile",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        UserEnabled = c.Boolean(),
                        CreationDate = c.DateTime(),
                        CreationMonth = c.Short(),
                        CreationYear = c.Short(),
                        ModificationDate = c.DateTime(),
                        ModificationMonth = c.Short(),
                        ModificationYear = c.Short(),
                        LastLoggedIn = c.DateTime(),
                        LastLoggedInMonth = c.Short(),
                        LastLoggedInYear = c.Short(),
                        LastProfileUpdate = c.DateTime(),
                        LastProfileUpdateMonth = c.Short(),
                        LastProfileUpdateYear = c.Short(),
                        UserType = c.String(),
                        Visible = c.Boolean(),
                        Status = c.String(),
                        Federated = c.Boolean(),
                        NameVisible = c.Boolean(),
                        EmailVisible = c.Boolean(),
                        OrangeEmployeeType = c.String(),
                        Title = c.String(),
                        Biography = c.String(),
                        OrangeEmployeeStatus = c.String(),
                        Department = c.String(),
                        CVPaste_Optional = c.String(),
                        WorkActivities = c.String(),
                        PhoneNumber = c.String(),
                        OrangeCUID = c.String(),
                        MobilePhoneNumber = c.String(),
                        MyObjectivesAndGoals = c.String(),
                        CharterSigned = c.Boolean(),
                        DigitalPassport = c.Boolean(),
                        AlternativePhone = c.String(),
                        M2AndCommunity = c.String(),
                        CVPaste = c.String(),
                        ROICode = c.String(),
                        BillingCode = c.String(),
                        Expertise = c.String(),
                        Execs = c.Boolean(),
                        Company = c.String(),
                        Interests = c.String(),
                        Schools = c.String(),
                        Birthday = c.String(),
                        OrangeAddress = c.String(),
                        FunFact = c.String(),
                        Languages = c.String(),
                        GIRStatus = c.Boolean(),
                        GIRBirthdate = c.DateTime(),
                        Points = c.Long(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Role_ID = c.Long(),
                        User_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_Membership_Role", t => t.Role_ID)
                .ForeignKey("dbo.User", t => t.User_ID)
                .Index(t => t.Role_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        HashedPassword = c.String(nullable: false, maxLength: 200),
                        Salt = c.String(nullable: false, maxLength: 200),
                        IsLocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "User_ID", "dbo.User");
            DropForeignKey("dbo.UserRole", "Role_ID", "dbo.tbl_Membership_Role");
            DropIndex("dbo.UserRole", new[] { "User_ID" });
            DropIndex("dbo.UserRole", new[] { "Role_ID" });
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.tbl_pz_profile");
            DropTable("dbo.tbl_pz_expertise");
            DropTable("dbo.tbl_pz_activity");
            DropTable("dbo.tbl_pz_statuslevelpoint");
            DropTable("dbo.tbl_pz_socialgroup");
            DropTable("dbo.tbl_Membership_Role");
            DropTable("dbo.tbl_pz_project");
            DropTable("dbo.tbl_pz_profile_his");
            DropTable("dbo.tbl_pz_userrelation");
            DropTable("dbo.tbl_pz_groupmember");
            DropTable("dbo.tbl_pz_community");
            DropTable("dbo.tbl_pz_blog");
            DropTable("dbo.tbl_od_identity");
            DropTable("dbo.tbl_od_entity");
            DropTable("dbo.tbl_pz_objecttag");
            DropTable("dbo.tbl_gir_identity");
            DropTable("dbo.Error");
        }
    }
}
