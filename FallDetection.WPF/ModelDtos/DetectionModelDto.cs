using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDetection.WPF.ModelDtos
{
    public class DetectionModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime FallDate { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
