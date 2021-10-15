using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.TestDouble.Untestable;
using Business.Tests.SetupAndTeardown.TestDouble;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Business.Tests
{
    public class CustomerTests
    {
        public class CustomerTestsWithMockingFramework
        {
            [Test]
            public void CalculateWage_HourlyPayed_ReturnsCorrectWage()
            {
                var gateway = Substitute.For<IDbGateway>();
                var ws = new WorkingStatistics(){PayHourly = true,HourSalary = 100,WorkingHours = 10};

                gateway.GetWorkingStatistics(Arg.Any<int>()).ReturnsForAnyArgs(ws);
                gateway.Connected.Returns(true);

                const decimal expectedWage = 10 * 100;
                var customer = new Customer(gateway, Substitute.For<ILogger>());

                decimal actualWage = customer.CalculateWage(0);
                
                Assert.That(actualWage, Is.EqualTo(expectedWage).Within(0.1));

            }

            [Test]
            public void CalculateWage_PassesCorrectId()
            {
                const int id = 1;
                var gateway = Substitute.For<IDbGateway>();
                gateway.GetWorkingStatistics(id).ReturnsForAnyArgs(new WorkingStatistics());

                var customer = new Customer(gateway, Substitute.For<ILogger>());
                customer.CalculateWage(1);

                gateway.Received().GetWorkingStatistics(id);

            }

            [Test]
            public void CalculateWage_ThrowsException_Returns0() {
                var gateway = Substitute.For<IDbGateway>();
                gateway.GetWorkingStatistics(Arg.Any<int>()).Throws(new InvalidOperationException());

                var sut = new Customer(gateway, Substitute.For<ILogger>());

                decimal actual = sut.CalculateWage(10);
                Assert.That(actual, Is.EqualTo(0));
            }

        }
        [Test]
        public void CalculateWage_HourlyPayed_ReturnsCorrectWage()
        {
            DbGatewayStub gateway = new DbGatewayStub();
            gateway.SetWorkingStatistics(new WorkingStatistics()
            {
                PayHourly = true,
                HourSalary = 100,
                WorkingHours = 10
            });
           
            var sut = new Customer(gateway, new LoggerDummy());

            const int anyId = 1;
            decimal actual = sut.CalculateWage(anyId);

            const decimal expectedWage = 100 * 10;
            Assert.That(actual, Is.EqualTo(expectedWage).Within(0.1));
        }

       [Test]
       public void CalculateWage_PassesCorrectId()
        {
            const int id= 1;

            var gateway = new DbGatewaySpy();
            gateway.SetWorkingStatistics(new WorkingStatistics());

            var sut = new Customer(gateway, new LoggerDummy());

            sut.CalculateWage(id);

            Assert.That(1, Is.EqualTo(gateway.Id));
        }

        [Test]
        public void CalculateWage_PassesCorrectId2()
        {
            const int id = 1;

            var gateway = new DbGatewayMock();
            gateway.SetWorkingStatistics(new WorkingStatistics());

            var sut = new Customer(gateway, new LoggerDummy());

            sut.CalculateWage(id);

            Assert.IsTrue(gateway.VerifyCalledWithProperId(id));
        }

    }
}
