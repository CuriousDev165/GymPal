﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymPal.Core.Interfaces;
using GymPal.Core.Services;
using GymPal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal.Core.ViewModels
{
    public partial class RecordsPageViewModel(IRepository _repo, MovementService _movementService) : ObservableObject
    {
        private readonly IRepository repo = _repo;
        private readonly MovementService movementService = _movementService;
        public ObservableCollection<string> Movements => movementService.Movements;
        [ObservableProperty]
        public partial string CurrentMovement { get; set; }
        public ObservableCollection<WeightTrainingMovement> MovementRecords { get; set; } = [];

        [RelayCommand]
        public async Task GetMovementsAsync()
        {
            movementService.Movements.Clear();

            var movements = await repo.GetRecordsAsync();
            foreach(var movement in movements)
            {
                if(movement.Name != null)
                movementService.Movements.Add(movement.Name);
            }
        }

        [RelayCommand]
        public async Task GetMovementRecordsAsync()
        {
            MovementRecords.Clear();

            var records = await repo.GetRecordsAsync(new WeightTrainingMovement { Name = CurrentMovement });
            foreach(WeightTrainingMovement record in records.Cast<WeightTrainingMovement>())
            {
                MovementRecords.Add(new WeightTrainingMovement
                {
                    Name = record.Name,
                    Date = record.Date,
                    SetNumber = record.SetNumber,
                    Weight = record.Weight,
                    Reps = record.Reps
                });
            }
        }
    }
}
