namespace SabaSoftwareLock.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MemberSoftwareNames", "MemberId", "dbo.Members");
            DropIndex("dbo.MemberSoftwareNames", new[] { "MemberId" });
            CreateTable(
                "dbo.SoftwareInfoes",
                c => new
                    {
                        SoftwareInfoId = c.Int(nullable: false, identity: true),
                        SoftwareName = c.String(),
                        SoftwareUniqueName = c.String(),
                        Member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.SoftwareInfoId)
                .ForeignKey("dbo.Members", t => t.Member_MemberId)
                .Index(t => t.Member_MemberId);
            
            CreateTable(
                "dbo.SerialTrackingCodes",
                c => new
                    {
                        SerialTrackingCodeId = c.Int(nullable: false, identity: true),
                        SoftwareInfoId = c.Int(nullable: false),
                        SerialUsingCount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SerialTrackingCodeId)
                .ForeignKey("dbo.SoftwareInfoes", t => t.SoftwareInfoId, cascadeDelete: true)
                .Index(t => t.SoftwareInfoId);
            
            CreateTable(
                "dbo.UserSerials",
                c => new
                    {
                        UserSerialId = c.Int(nullable: false, identity: true),
                        PackageSerialId = c.Int(nullable: false),
                        UserSerialStateId = c.Int(nullable: false),
                        SerialTrackingCodeId = c.Int(nullable: false),
                        UsedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserSerialId)
                .ForeignKey("dbo.PackageSerials", t => t.PackageSerialId, cascadeDelete: true)
                .ForeignKey("dbo.UserSerialStates", t => t.UserSerialStateId, cascadeDelete: true)
                .ForeignKey("dbo.SerialTrackingCodes", t => t.SerialTrackingCodeId, cascadeDelete: true)
                .Index(t => t.PackageSerialId)
                .Index(t => t.UserSerialStateId)
                .Index(t => t.SerialTrackingCodeId);
            
            CreateTable(
                "dbo.PackageSerials",
                c => new
                    {
                        PackageSerialId = c.Int(nullable: false, identity: true),
                        Serial = c.String(),
                    })
                .PrimaryKey(t => t.PackageSerialId);
            
            CreateTable(
                "dbo.HardwareSerials",
                c => new
                    {
                        HardwareSerialId = c.Int(nullable: false, identity: true),
                        Serial = c.String(),
                        UserSerial_UserSerialId = c.Int(),
                    })
                .PrimaryKey(t => t.HardwareSerialId)
                .ForeignKey("dbo.UserSerials", t => t.UserSerial_UserSerialId)
                .Index(t => t.UserSerial_UserSerialId);
            
            CreateTable(
                "dbo.UserSerialStates",
                c => new
                    {
                        UserSerialStateId = c.Int(nullable: false, identity: true),
                        LastEnablingState = c.String(),
                    })
                .PrimaryKey(t => t.UserSerialStateId);
            
            CreateTable(
                "dbo.UserSerialSettings",
                c => new
                    {
                        UserSerialSettingId = c.Int(nullable: false, identity: true),
                        Settings = c.String(),
                    })
                .PrimaryKey(t => t.UserSerialSettingId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropTable("dbo.MemberSoftwareNames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemberSoftwareNames",
                c => new
                    {
                        MemberSoftwareNameId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        TrackingId = c.Int(nullable: false),
                        SoftwareName = c.String(),
                    })
                .PrimaryKey(t => t.MemberSoftwareNameId);
            
            DropIndex("dbo.HardwareSerials", new[] { "UserSerial_UserSerialId" });
            DropIndex("dbo.UserSerials", new[] { "SerialTrackingCodeId" });
            DropIndex("dbo.UserSerials", new[] { "UserSerialStateId" });
            DropIndex("dbo.UserSerials", new[] { "PackageSerialId" });
            DropIndex("dbo.SerialTrackingCodes", new[] { "SoftwareInfoId" });
            DropIndex("dbo.SoftwareInfoes", new[] { "Member_MemberId" });
            DropForeignKey("dbo.HardwareSerials", "UserSerial_UserSerialId", "dbo.UserSerials");
            DropForeignKey("dbo.UserSerials", "SerialTrackingCodeId", "dbo.SerialTrackingCodes");
            DropForeignKey("dbo.UserSerials", "UserSerialStateId", "dbo.UserSerialStates");
            DropForeignKey("dbo.UserSerials", "PackageSerialId", "dbo.PackageSerials");
            DropForeignKey("dbo.SerialTrackingCodes", "SoftwareInfoId", "dbo.SoftwareInfoes");
            DropForeignKey("dbo.SoftwareInfoes", "Member_MemberId", "dbo.Members");
            DropTable("dbo.Users");
            DropTable("dbo.UserSerialSettings");
            DropTable("dbo.UserSerialStates");
            DropTable("dbo.HardwareSerials");
            DropTable("dbo.PackageSerials");
            DropTable("dbo.UserSerials");
            DropTable("dbo.SerialTrackingCodes");
            DropTable("dbo.SoftwareInfoes");
            CreateIndex("dbo.MemberSoftwareNames", "MemberId");
            AddForeignKey("dbo.MemberSoftwareNames", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
        }
    }
}
