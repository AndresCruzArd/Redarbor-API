using Moq;
using FluentAssertions;
using Redarbor.Application.Services;
using Redarbor.Domain.Interfaces;
using Redarbor.Domain.Entities;

namespace Redarbor.Tests.Services
{
    public class JobServiceTests
    {
        [Fact]
        public async Task GetById_ShouldReturnJob_WhenJobExists()
        {
            // Arrange
            var mockRepository = new Mock<IJobRepository>();

            var job = new Job
            {
                Id = 1,
                Title = "Backend Developer"
            };

            mockRepository
                .Setup(r => r.GetById(1))
                .ReturnsAsync(job);

            var service = new JobService(mockRepository.Object);

            // Act
            var result = await service.GetById(1);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Title.Should().Be("Backend Developer");
        }
    }
}