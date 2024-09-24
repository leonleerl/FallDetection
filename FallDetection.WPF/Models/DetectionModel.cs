using System;

namespace FallDetection.WPF.Models
{
    public class DetectionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime FallDate { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
