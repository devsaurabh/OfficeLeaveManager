namespace LM.WpfClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_commit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeLeaves",
                c => new
                    {
                        EmployeeLeaveId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        MonthlyLeaveId = c.Int(nullable: false),
                        Leave = c.Int(nullable: false),
                        LeaveDate = c.DateTime(nullable: false),
                        LeaveDuration = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeLeaveId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.MonthlyLeaves", t => t.MonthlyLeaveId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.MonthlyLeaveId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeCode = c.Int(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        WorkShift = c.Int(nullable: false),
                        EmployeeType = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CompOffs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarryForward = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.MonthlyLeaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneratedOn = c.DateTime(nullable: false),
                        WorkingDays = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        WorkShift = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveType = c.Int(nullable: false),
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ForYear = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeLeaves", "MonthlyLeaveId", "dbo.MonthlyLeaves");
            DropForeignKey("dbo.EmployeeLeaves", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeLeaves", new[] { "MonthlyLeaveId" });
            DropIndex("dbo.EmployeeLeaves", new[] { "EmployeeId" });
            DropTable("dbo.Leaves");
            DropTable("dbo.Holidays");
            DropTable("dbo.MonthlyLeaves");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeLeaves");
        }
    }
}
