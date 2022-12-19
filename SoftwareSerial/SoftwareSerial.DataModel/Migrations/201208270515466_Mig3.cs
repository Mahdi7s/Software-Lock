namespace SoftwareSerial.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SerialTrackingCodes", "SoftwareInfoId", "dbo.SoftwareInfoes");
            DropIndex("dbo.SerialTrackingCodes", new[] { "SoftwareInfoId" });
            AlterColumn("dbo.SerialTrackingCodes", "SoftwareInfoId", c => c.Int(nullable: false));
            AddForeignKey("dbo.SerialTrackingCodes", "SoftwareInfoId", "dbo.SoftwareInfoes", "SoftwareInfoId", cascadeDelete: true);
            CreateIndex("dbo.SerialTrackingCodes", "SoftwareInfoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SerialTrackingCodes", new[] { "SoftwareInfoId" });
            DropForeignKey("dbo.SerialTrackingCodes", "SoftwareInfoId", "dbo.SoftwareInfoes");
            AlterColumn("dbo.SerialTrackingCodes", "SoftwareInfoId", c => c.Int());
            CreateIndex("dbo.SerialTrackingCodes", "SoftwareInfoId");
            AddForeignKey("dbo.SerialTrackingCodes", "SoftwareInfoId", "dbo.SoftwareInfoes", "SoftwareInfoId");
        }
    }
}
