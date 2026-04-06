using MauiApp2.Model;

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
            // Act
            // Assert
        }
    }
}
