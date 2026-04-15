using FluentAssertions;
using BL.Model;

namespace MauiApp2Tests
{
    public class GoalDtoTests
    {
        [Fact]
        public void CalculateProgress_WhenStartEarlierThanEndGivenThenZero()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 1);
            var sut = new GoalDto();
            var expectedResult = 0.0F;
            // Act
            var actualResult = sut.CalculateProgress(start, end);
            // Assert
            actualResult.Should().Be(expectedResult, "because start is before end");
        }
        [Fact]
        public void CalculateProgress_WhenStartSameAsEndGivenThenOne()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 5);
            var sut = new GoalDto();
            var expectedResult = 1.0F;
            // Act
            var actualResult = sut.CalculateProgress(start, end);
            // Assert
            actualResult.Should().Be(expectedResult, "because start is same day as end");
        }
        [Fact]
        public void GivenMethodCalled_WhenEndNextDay_ThenProgress50Percent()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 6);
            var sut = new GoalDto();
            var expectedResult = 0.5F;
            // Act
            var actualResult = sut.CalculateProgress(start, end);
            // Assert
            actualResult.Should().Be(expectedResult, "because start is next day");
        }
        [Fact]
        public void GivenMethodCalled_WhenEndInTenDays_ThenProgress10Percent()
        {
            // Arrange
            var start = new DateTime(2026, 1, 5);
            var end = new DateTime(2026, 1, 15);
            var sut = new GoalDto();
            var expectedResult = 0.1F;
            // Act
            var actualResult = sut.CalculateProgress(start, end);
            // Assert
            actualResult.Should().Be(expectedResult, "because end is in 10 days");
        }

    }

}
