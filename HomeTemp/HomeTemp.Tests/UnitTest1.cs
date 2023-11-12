namespace HomeTemp.Tests
{
    public class Tests
    {
        [Test]
        public void WhenUserEnteredTemperatures_ShouldReturnedCorrectMaxResult()
        {
            // arrange
            var room = new RoomInMemory("");
            room.AddTemp(34);
            room.AddTemp(21);

            // act
            var result = room.GetStatistics().Max;

            // assert
            Assert.AreEqual(34, result);
        }

        [Test]
        public void WhenUserEnteredTemperatures_ShouldReturnedCorrectAverageResult()
        {
            // arrange
            var room = new RoomInMemory("");
            room.AddTemp(10);
            room.AddTemp(20);

            // act
            var result = room.GetStatistics().Average;

            // assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public void WhenUserEnteredTemperatures_ShouldReturnedCorrectCountResult()
        {
            // arrange
            var room = new RoomInMemory("");
            room.AddTemp(10);
            room.AddTemp(20);
            room.AddTemp(30);
            room.AddTemp(40);
            room.AddTemp(50);

            // act
            var result = room.GetStatistics().Count;

            // assert
            Assert.AreEqual(5, result);
        }
    }
}