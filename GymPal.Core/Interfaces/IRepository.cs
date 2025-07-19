using GymPal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal.Core.Interfaces
{
    /// <summary>
    /// Defines a contract for performing single CREATE, multiple READ, and single DELETE operations on a database.
    /// </summary>
    /// <typeparam name="B">The base class from which other classes in the interface implementation can inherit</typeparam>
    /// <typeparam name="C">A child class that inherits from the base class defined in parameter B</typeparam>
    public interface IRepository
    {

        /// <summary>
        /// Add a single movement name to the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="record"></param>
        /// <returns>The number of rows affected by the operation.</returns>
        Task<int> AddRecordAsync(Movement movement);

        /// <summary>
        /// Add a single weight training record to the database.
        /// </summary>
        /// <param name="movement"></param>
        /// <returns></returns>
        Task<int> AddRecordAsync(WeightTrainingMovement movement);

        /// <summary>
        /// Get multiple records from the database. Implement for the default behavior of retrieving all records for the given context.
        /// </summary>
        /// <returns></returns>
        Task<List<Movement>> GetRecordsAsync();

        /// <summary>
        /// Retrieve multiple records from the database in a single operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <returns>All records returned by the operation.</returns>
        Task<List<WeightTrainingMovement>> GetRecordsAsync(WeightTrainingMovement movement);

        /// <summary>
        /// Delete a single record from the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <returns>The number of rows affected by the operation.</returns>
        Task<int> DeleteRecordAsync(Movement movement);
    }
}
