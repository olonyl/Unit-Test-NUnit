using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace Business.Tests
{
    public class DeviceTests
    {
        [Test]
        public void Connect_FailedThrice_ThreeTries()
        {
            IProtocol provider = Substitute.For<IProtocol>();
            
            provider.Connect(Arg.Any<string>()).Returns(false);
            //provider.Connect(Arg.Is("COM1")).Returns(true);
            //provider.Connect(Arg.Is<string>(x => x.StartsWith("COM"))).Returns(true);

            var sut = new Device(provider);

            sut.Connect(string.Empty);

            provider.Received(3).Connect(Arg.Any<string>());

        }

        [Test]
        public void Find_FoundOnCOM1_ReturnsCOM1()
        {
            IProtocol provider = Substitute.For<IProtocol>();
            var sut = new Device(provider);

            Task<string> task = sut.Find();

            const string portName = "COM1";

            provider.SearchingFinished += Raise.Event<EventHandler<DeviceSearchingEventArgs>>(provider, new DeviceSearchingEventArgs(portName));

            Assert.That(task.Result, Is.EqualTo(portName));
        }
    }
}
