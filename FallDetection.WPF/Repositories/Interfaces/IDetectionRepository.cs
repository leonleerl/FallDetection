using FallDetection.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDetection.WPF.Repositories.Interfaces
{
    public interface IDetectionRepository
    {
        Task<IEnumerable<DetectionModel>> GetAllAsync();
        Task<IEnumerable<DetectionModel>> GetByNameAsync(string name);
    }
}
