using ADPTest.Application.Abstract;
using ADPTest.Application.Services;
using ADPTest.Domain.Abstract.Repository;
using ADPTest.Repository.Context;
using ADPTest.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace ADPTest.Tests
{
    [TestClass]
    public class UnitTest1
    {

        private readonly IAdpTestService adpTestService;

        public UnitTest1()
        {
            var services = new ServiceCollection();
            services.AddTransient<IAdpTestService, ADPTestService>();
            services.AddTransient<IAdpTestRepository, AdpTestRepository>();

          //  services.AddDbContext<AdpContext>(options => options.UseSqlServer(Configuration\["ConnectionStrings:DefaultConnection"\]));

            var serviceProvider = services.BuildServiceProvider();

            adpTestService = serviceProvider.GetService<IAdpTestService>();

        }

        [TestMethod]
        public void TestMethod_Addition()
        {
            var result = adpTestService.GetOperationResult(10, 20, "addition");
            Assert.AreEqual(result, 30); 

        }

        [TestMethod]
        public void TestMethod_Subtraction()
        {
            var result = adpTestService.GetOperationResult(10, 20, "subtraction");
            Assert.AreEqual(result, -10);
        }

        [TestMethod]
        public void TestMethod_Division()
        {
            var result = adpTestService.GetOperationResult(35420, 20, "division");
            Assert.AreEqual(result, 1771);
        }

        [TestMethod]
        public void TestMethod_Multiplication()
        {
            var result = adpTestService.GetOperationResult(10, 20, "multiplication");
            Assert.AreEqual(result, 200);
        }

        [TestMethod]
        public void TestMethod_Remainder()
        {
            var result = adpTestService.GetOperationResult(4554, 30, "remainder");
            Assert.AreEqual(result, 24);
        }
    }
}