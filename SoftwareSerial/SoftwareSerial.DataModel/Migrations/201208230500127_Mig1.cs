namespace SoftwareSerial.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SoftwareInfoes",
                c => new
                    {
                        SoftwareInfoId = c.Int(nullable: false, identity: true),
                        SoftwareName = c.String(),
                        SoftwareUniqueName = c.String(),
                    })
                .PrimaryKey(t => t.SoftwareInfoId);
            
            AddColumn("dbo.SerialTrackingCodes", "SoftwareInfoId", c => c.Int(nullable: true));
            AddForeignKey("dbo.SerialTrackingCodes", "SoftwareInfoId", "dbo.SoftwareInfoes", "SoftwareInfoId", cascadeDelete: true);
            CreateIndex("dbo.SerialTrackingCodes", "SoftwareInfoId");
            DropColumn("dbo.SerialTrackingCodes", "SoftwareName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SerialTrackingCodes", "SoftwareName", c => c.String());
            DropIndex("dbo.SerialTrackingCodes", new[] { "SoftwareInfoId" });
            DropForeignKey("dbo.SerialTrackingCodes", "SoftwareInfoId", "dbo.SoftwareInfoes");
            DropColumn("dbo.SerialTrackingCodes", "SoftwareInfoId");
            DropTable("dbo.SoftwareInfoes");
        }
    }
}
