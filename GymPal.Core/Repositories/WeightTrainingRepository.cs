using GymPal.Interfaces;
using GymPal.Models;

namespace GymPal.Repositories
{
    // Repository for working with weight training records in a database.
    public class WeightTrainingRepository : IRepository
    {
        public async Task<int> AddRecordAsync<WeightTrainingMovement>(WeightTrainingMovement record) where WeightTrainingMovement : class
        {
            throw new NotImplementedException();
        }

        public async Task<Movement> GetRecordAsync<Movement>(Movement argument) where Movement : class
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movement>> GetRecordsAsync<Movement>(Movement argument) where Movement : class
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteRecordAsync<Movement>(Movement argument) where Movement : class
        {
            throw new NotImplementedException();
        }
    }
}
