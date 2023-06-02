using Moq;

namespace test
{
    public class UnitTest1
    {
        public readonly Mock<FlightOptimizer> _flightOptimizer;
        public UnitTest1()
        {
            _flightOptimizer = new Mock<FlightOptimizer>();
        }
        [Fact]
        public void GeneratePassengersAndFamiliesTest()
        {
            var Result = _flightOptimizer.Object.GeneratePassengersAndFamilies();
            Assert.NotEmpty(Result);
        }
        [Fact]
        public void AddMemberTest()
        {
            var familiy = new Family();
            familiy.AddMember(new Passenger(1, "Ahmed", "A", 30, true));
            familiy.AddMember(new Passenger(2, "laila", "B", 10, false));
            familiy.AddMember(new Passenger(3, "zineb", "c", 57, false));
            var count = familiy.Members.Count();
            Assert.Equal(3, count);
        }
    }
}