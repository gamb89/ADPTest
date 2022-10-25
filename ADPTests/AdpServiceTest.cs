
using ADPTest.Application.Abstract;
using ADPTest.Application.Services;
using Moq;
namespace ADPTests
{
    public class AdpServiceTest
    {
        private IAdpTestService _testService;
        public AdpServiceTest(IAdpTestService testService)
        {
            _testService = testService;
        }

       [Fact]
        public void GetOperationResultAddition_Test()
        {
            var result = _testService.GetOperationResult(20, 10, "addition");

            Assert.True(result == 30); 
        }

        [Fact]
        public void GetOperationResultDivsion_Test()
        {
            var result = _testService.GetOperationResult(20, 10, "division");

            Assert.True(result == 2);
        }
        [Fact]
        public void GetOperationResultRemainder_Test()
        {
            var result = _testService.GetOperationResult(550450, 100, "remainder");

            Assert.True(result == 10);
        }

    }
}