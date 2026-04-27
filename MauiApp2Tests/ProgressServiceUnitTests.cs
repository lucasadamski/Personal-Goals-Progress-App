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

        // Days after start 

        [Fact]
        public void WhenCalculateDaysAfterStartCalled_GivenStartTomorrow_ThenReturnsZero()
        {
            // Arrange
            var expectedResult = 0;
            var start = new DateTime(2026, 1, 15);
            var today = new DateTime(2026, 1, 14);
            var sut = new ProgressService();
            // Act
            var actualResult = sut.CalculateDaysAfterStart(DateOnly.FromDateTime(start), DateOnly.FromDateTime(today));
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WhenCalculateDaysAfterStartCalled_GivenStartSameDay_ThenReturnsZero()
        {
            // Arrange
            var expectedResult = 0;
            var start = new DateTime(2026, 1, 14);
            var today = new DateTime(2026, 1, 14);
            var sut = new ProgressService();
            // Act
            var actualResult = sut.CalculateDaysAfterStart(DateOnly.FromDateTime(start), DateOnly.FromDateTime(today));
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WhenCalculateDaysAfterStartCalled_GivenStartYesterday_ThenReturnsOne()
        {
            // Arrange
            var expectedResult = 1;
            var start = new DateTime(2026, 1, 13);
            var today = new DateTime(2026, 1, 14);
            var sut = new ProgressService();
            // Act
            var actualResult = sut.CalculateDaysAfterStart(DateOnly.FromDateTime(start), DateOnly.FromDateTime(today));
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WhenCalculateDaysAfterStartCalled_GivenStartSevenDaysAgo_ThenReturnsSeven()
        {
            // Arrange
            var expectedResult = 7;
            var start = new DateTime(2026, 1, 7);
            var today = new DateTime(2026, 1, 14);
            var sut = new ProgressService();
            // Act
            var actualResult = sut.CalculateDaysAfterStart(DateOnly.FromDateTime(start), DateOnly.FromDateTime(today));
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }


        // Days left to the end
        [Fact]
        public void WhenCalculateDaysLeftToEndCalled_GivenEndYesterday_ThenReturnsZero()
        {
            // Arrange
            var expectedResult = 0;
            var end = new DateTime(2026, 1, 13);
            var today = new DateTime(2026, 1, 14);
            var sut = new ProgressService();
            // Act
            var actualResult = sut.CalculateDaysLeftToEnd(DateOnly.FromDateTime(end), DateOnly.FromDateTime(today));
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WhenCalculateDaysLeftToEndCalled_GivenEndToday_ThenReturnsZero()
        {
            // Arrange
            var expectedResult = 0;
            var end = new DateTime(2026, 1, 14);
            var today = new DateTime(2026, 1, 14);
            var sut = new ProgressService();
            // Act
            var actualResult = sut.CalculateDaysLeftToEnd(DateOnly.FromDateTime(end), DateOnly.FromDateTime(today));
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WhenCalculateDaysLeftToEndCalled_GivenEndInOneDay_ThenReturnsOne()
        {
            // Arrange
            var expectedResult = 1;
            var end = new DateTime(2026, 1, 15);
            var today = new DateTime(2026, 1, 14);
            var sut = new ProgressService();
            // Act
            var actualResult = sut.CalculateDaysLeftToEnd(DateOnly.FromDateTime(end), DateOnly.FromDateTime(today));
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void WhenCalculateDaysLeftToEndCalled_GivenEndInSevenDays_ThenReturnsSeven()
        {
            // Arrange
            var expectedResult = 7;
            var end = new DateTime(2026, 1, 21);
            var today = new DateTime(2026, 1, 14);
            var sut = new ProgressService();
            // Act
            var actualResult = sut.CalculateDaysLeftToEnd(DateOnly.FromDateTime(end), DateOnly.FromDateTime(today));
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }


}
