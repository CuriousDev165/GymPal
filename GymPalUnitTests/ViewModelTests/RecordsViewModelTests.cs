using GymPal.Core.Interfaces;
using GymPal.Core.Services;
using GymPal.Core.ViewModels;
using GymPal.Models;
using Moq;

namespace GymPal.UnitTests.ViewModelTests
{
    public class RecordsViewModelTests
    {
        private readonly RecordsPageViewModel viewModel;
        private readonly Mock<IRepository> mockRepo = new();
        private readonly MovementService movementService = new();

        public RecordsViewModelTests()
        {
            viewModel = new (mockRepo.Object, movementService);
        }

        [Fact]
        public async Task GetMovementsAsync_RefreshesMovementList()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetRecordsAsync(It.IsAny<WeightTrainingMovement>()))
                .ReturnsAsync([new WeightTrainingMovement { Name = "Movement 1" }]);

            // Act
            await viewModel.GetMovementsAsync();

            // Assert
            Assert.Single(movementService.Movements);
            Assert.Equal("Movement 1", movementService.Movements[0]);
        }

        [Fact]
        public async Task GetMovementRecordsAsync_RefreshesMovementRecords()
        {
            // Arrange
            viewModel.CurrentMovement = "Movement 1";
            mockRepo.Setup(repo => repo.GetRecordsAsync(It.IsAny<WeightTrainingMovement>()))
                .ReturnsAsync([new WeightTrainingMovement { Name = "Movement 1", Date = "2025-01-01", SetNumber = 3, Weight = 100, Reps = 10 }]);

            // Act
            await viewModel.GetMovementRecordsAsync();

            // Assert
            Assert.Single(viewModel.MovementRecords);
            Assert.Equal("Movement 1", viewModel.MovementRecords[0].Name);
            Assert.Equal(3, viewModel.MovementRecords[0].SetNumber);
            Assert.Equal(100, viewModel.MovementRecords[0].Weight);
            Assert.Equal(10, viewModel.MovementRecords[0].Reps);
        }
    }
}
