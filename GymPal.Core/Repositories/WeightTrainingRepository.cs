using GymPal.Core.Interfaces;
using GymPal.Models;
using SQLite;
using System.IO.Enumeration;

namespace GymPal.Core.Repositories
{
    // Repository for working with weight training records in a database.
    public class WeightTrainingRepository : IRepository
    {

        private readonly SQLiteAsyncConnection conn;

        public WeightTrainingRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            Task.Run(async () => await InitAsync());
        }
        private async Task InitAsync()
        {
            await conn.CreateTableAsync<Movement>();
            await conn.CreateTableAsync<WeightTrainingMovement>();
        }
        
        public async Task<int> AddRecordAsync(Movement movement) => await conn.InsertAsync(movement);

        public async Task<int> AddRecordAsync(WeightTrainingMovement movement) => await conn.InsertAsync(movement);


        // Retrieve movement names from the database.
        public async Task<List<Movement>> GetRecordsAsync()
        {
            var records = await conn.Table<Movement>().ToListAsync();

            List<Movement> movements = [];
            foreach (var record in records)
            {
                movements.Add(record);
            }

            return movements;
        }

        // Retrieve recrords for a specific weight training movement.
        public async Task<List<WeightTrainingMovement>> GetRecordsAsync(WeightTrainingMovement movement) => 
            await conn.Table<WeightTrainingMovement>()
                .Where(m => m.Name == movement.Name)
                .ToListAsync();

        public async Task<int> DeleteRecordAsync(Movement movement)
        {
            string query = "$DELETE FROM movement WHERE name = ?";
            int rowsAffected = await conn.ExecuteAsync(query, movement.Name);

            query = "$DELETE FROM weight_training_movement WHERE name = ?";
            rowsAffected += await conn.ExecuteAsync(query, movement.Name);

            return rowsAffected;
        }
    }
}
