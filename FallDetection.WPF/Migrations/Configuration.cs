namespace FallDetection.WPF.Migrations
{
    using FallDetection.WPF.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FallDetection.WPF.Data.FallDetectionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FallDetection.WPF.Data.FallDetectionDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.DetectionModels.AddOrUpdate(
                p => p.Name,
                new DetectionModel() { Id = Guid.NewGuid(), Name = "Tom Smith", FallDate = new DateTime(2005, 8, 29), Longitude = "115.576350", Latitude = "-32.047567" },
                new DetectionModel() { Id = Guid.NewGuid(), Name = "James Williams", FallDate = new DateTime(2016, 11, 27), Longitude = "115.989746", Latitude = "-32.186290" },
                new DetectionModel() { Id = Guid.NewGuid(), Name = "Jenny Brown", FallDate =  new DateTime(2008, 9, 16), Longitude = "115.608488", Latitude = "-31.969587" }
                );
        }
    }
}
