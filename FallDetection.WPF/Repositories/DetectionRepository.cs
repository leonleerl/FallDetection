using FallDetection.WPF.Data;
using FallDetection.WPF.Models;
using FallDetection.WPF.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDetection.WPF.Repositories
{
    public class DetectionRepository : IDetectionRepository
    {
        private readonly FallDetectionDbContext _dbContext;
        public DetectionRepository() {
            _dbContext = new FallDetectionDbContext();
        }
        public async Task<IEnumerable<DetectionModel>> GetAllAsync()
        {
            return await _dbContext.DetectionModels.ToListAsync();
        }

        public async Task<IEnumerable<DetectionModel>> GetByNameAsync(string name)
        {
            return await _dbContext.DetectionModels.Where(p => p.Name.Contains(name)).ToListAsync();
        }
    }
}
