using FluentAssertions;
using BL.Services;

namespace MauiApp2Tests
{
    public class ProgressServiceUnitTests
    {

        [Fact]
        public void WhenCalculateProgressCalled_GivenStartLaterThanEnd_ThenReturnsZero()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 1);
            var today = new DateTime(2026, 1, 5);

            var sut = new ProgressService();
            var expectedResult = 0.0F;
            // Act
            var actualResult = sut.CalculateProgress(start, end, today);
            // Assert
            actualResult.Should().Be(expectedResult);
        }
        [Fact]
        public void WhenCalculateProgressCalled_GivenStartSameAsEndTodaySameDay_ThenReturnsZero()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 5);
            var today = new DateTime(2026, 1, 5);

            var sut = new ProgressService();
            var expectedResult = 0.0F;
            // Act
            var actualResult = sut.CalculateProgress(start, end, today);
            // Assert
            actualResult.Should().Be(expectedResult);
        }
        [Fact]
        public void WhenCalculateProgressCalled_GivenStartSameAsEndTodayTomorrow_ThenReturnsOne()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 5);
            var today = new DateTime(2026, 1, 6);

            var sut = new ProgressService();
            var expectedResult = 1.0F;
            // Act
            var actualResult = sut.CalculateProgress(start, end, today);
            // Assert
            actualResult.Should().Be(expectedResult);
        }
        [Fact]
        public void WhenCalculateProgressCalled_GivenEndNextDay_ThenReturnsProgress0Percent()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 6);
            var today = new DateTime(2026, 1, 5);

            var sut = new ProgressService();
            var expectedResult = 0.0F;
            // Act
            var actualResult = sut.CalculateProgress(start, end, today);
            // Assert
            actualResult.Should().Be(expectedResult);
        }
        [Fact]
        public void WhenCalculateProgressCalled_GivenEndInTenDays_ThenReturnsProgress10Percent()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 15);
            var today = new DateTime(2026, 1, 6);


            var sut = new ProgressService();
            var expectedResult = 0.1D;
            // Act
            var actualResult = sut.CalculateProgress(start, end, today);
            // Assert
            Math.Round(actualResult, 1).Should().Be(expectedResult);
        }

        [Fact]
        public void WhenCalculateProgressCalled_GivenEndTomorrowAndStartedNineDaysAgo_ThenReturnsProgress90Percent()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 15);
            var today = new DateTime(2026, 1, 14);


            var sut = new ProgressService();
            var expectedResult = 0.9D;
            // Act
            var actualResult = sut.CalculateProgress(start, end, today);
            // Assert
            Math.Round(actualResult, 1).Should().Be(expectedResult);
        }

    }

}
