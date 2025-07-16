using GymPal.Interfaces;

namespace GymPal.Repositories
{
    // Repository for working with weight training records in a database.
    public class WeightTrainingRepository : IRepository
    {
        public async Task<int> AddRecordAsync<WeightTrainingMovement>(WeightTrainingMovement record) where WeightTrainingMovement : class
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddRecords<WeightTrainingMovement>(IEnumerable<WeightTrainingMovement> records) where WeightTrainingMovement : class
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteRecordAsync<WeightTrainingMovement>(WeightTrainingMovement argument) where WeightTrainingMovement : class
        {
            throw new NotImplementedException();
        }

        public async Task<WeightTrainingMovement> GetRecordAsync<WeightTrainingMovement>(WeightTrainingMovement argument) where WeightTrainingMovement : class
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WeightTrainingMovement>> GetRecordsAsync<WeightTrainingMovement>(WeightTrainingMovement argument) where WeightTrainingMovement : class
        {
            throw new NotImplementedException();
        }
    }
}
