namespace FallDetection.WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetectionModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        FallDate = c.DateTime(nullable: false),
                        Longitude = c.String(),
                        Latitude = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DetectionModels");
        }
    }
}
