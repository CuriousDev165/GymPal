using CommunityToolkit.Mvvm.ComponentModel;
using GymPal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal.Core.Services
{
    public partial class MovementService : ObservableObject
    {
        [ObservableProperty]
        public partial ObservableCollection<string> Movements { get; set; } = [];
    }
}
