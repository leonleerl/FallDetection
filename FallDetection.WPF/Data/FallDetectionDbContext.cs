using FallDetection.WPF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDetection.WPF.Data
{
    public class FallDetectionDbContext : DbContext
    {
        public FallDetectionDbContext() : base("Data Source=RUNLONGLI;Initial Catalog=FallDetectionDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;")
        {
            
        }
        public DbSet<DetectionModel> DetectionModels { get; set; }
    }
}
