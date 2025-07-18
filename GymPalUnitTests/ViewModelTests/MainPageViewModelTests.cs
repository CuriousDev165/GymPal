using GymPal.Interfaces;
using GymPal.Models;
using GymPal.ViewModels;
using Moq;

namespace GymPal.UnitTests.ViewModelTests
{
    public class MainPageViewModelTests
    {
        private readonly MainPageViewModel viewModel;
        private readonly Mock<IRepository> mockRepo = new();

        private List<string> Movements { get; set; } = [];

        public MainPageViewModelTests()
        {
            viewModel = new (mockRepo.Object);
        }

        [Fact]
        public async Task AddNewMovementAsync_RefreshesMovementList()
        {
            // Arrange
            viewModel.NewMovement = "New Movement";
            mockRepo.Setup(repo => repo.AddRecordAsync(It.IsAny<Movement>()))
                .ReturnsAsync(1);
            mockRepo.Setup(repo => repo.GetRecordsAsync(It.IsAny<Movement>()))
                .ReturnsAsync([new() { Name = "New Movement" }]);

            // Act
            await viewModel.AddNewMovementAsync();

            // Assert
            Assert.Single(viewModel.Movements);
            Assert.Equal("New Movement", viewModel.Movements[0]);
            Assert.Empty(viewModel.NewMovement);
        }

        [Fact]
        public async Task GetMovementsAsync_RefreshesMovementList()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetRecordsAsync(It.IsAny<Movement>())).
                ReturnsAsync([new() { Name = "Movement 1" }]);

            // Act
            await viewModel.GetMovementsAsync();

            // Assert
            Assert.Single(viewModel.Movements);
            Assert.Equal("Movement 1", viewModel.Movements[0]);
        }

        [Fact]
        public void ResetSetValues_ResetsSetValues()
        {
            // Arrange
            viewModel.SetNumber = 2;
            viewModel.Weight = 100;
            viewModel.Reps = 10;

            // Act
            viewModel.ResetSetValues();

            // Assert
            Assert.Equal(1, viewModel.SetNumber);
            Assert.Equal(0, viewModel.Weight);
            Assert.Equal(0, viewModel.Reps);
        }

        [Fact]
        public async Task SaveSetAsync_ResetsSetValues()
        {
            // Arrange
            viewModel.SetNumber = 2;
            viewModel.Weight = 100;
            viewModel.Reps = 10;
            mockRepo.Setup(repo => repo.AddRecordAsync(It.IsAny<WeightTrainingMovement>()))
                .ReturnsAsync(1);
            // Act
            await viewModel.SaveSetAsync();

            // Assert
            Assert.Equal(1, viewModel.SetNumber);
            Assert.Equal(0, viewModel.Weight);
            Assert.Equal(0, viewModel.Reps);
        }
    }
}
