using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymPal.Interfaces;
using GymPal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal.ViewModels
{
    public partial class MainPageViewModel(IRepository _repo) : ObservableObject
    {
        private readonly IRepository repo = _repo;

        [ObservableProperty]
        public partial string NewMovement { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<string> Movements { get; set; } = [];
        [ObservableProperty]
        public partial string CurrentMovement { get; set; }
        // Defaults to the first set when the page loads.
        [ObservableProperty]
        public partial int SetNumber { get; set; } = 1;
        [ObservableProperty]
        public partial int Weight { get; set; }
        [ObservableProperty]
        public partial int Reps { get; set; }

        // Add a new movement to the movement table in the database, refresh the movement list, and clear the new movement field.
        [RelayCommand]
        public async Task AddNewMovementAsync()
        {
            var rowsAffected = await repo.AddRecordAsync(new Movement { Name = NewMovement });
            if(rowsAffected == 1)
            {
                // Refresh the movement list.
                Movements.Clear();
                await GetMovementsAsync();
            }

            NewMovement = string.Empty;
        }

        // Retrieve the list of movements from the database and populate the Movements collection.
        [RelayCommand]
        public async Task GetMovementsAsync()
        {
            var movements = await repo.GetRecordsAsync(new Movement { Name = string.Empty });
            foreach(var movement in movements)
            {
                Movements.Add(movement.Name);
            }
        }

        // Resets the set number, weight, and reps to their default values when either the current movement is changed or a set is saved.
        [RelayCommand]
        public void ResetSetValues()
        {
            SetNumber = 1;
            Weight = 0;
            Reps = 0;
        }

        // Save the current set to the database.
        [RelayCommand]
        public async Task SaveSetAsync()
        {
            await repo.AddRecordAsync(new WeightTrainingMovement
            {
                Name = CurrentMovement,
                Date = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd"),
                SetNumber = SetNumber,
                Weight = Weight,
                Reps = Reps
            });

            ResetSetValues();
        }
    }
}
