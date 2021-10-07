using NUnit.Framework;
using System;

namespace Business.Tests
{
    public class SerialPortParserTests
    {
        [Test]
        public void ParsePort_COM1_Returns1()
        {
            int restult = SerialPortParser.ParsePort("COM1");
            Assert.That(restult, Is.EqualTo(1));
        }

        [Test]
        public void ParsePort_InvalidFormat_ThrowsInvalidformatException()
        {
            TestDelegate action = () => SerialPortParser.ParsePort("1");
            Assert.Throws<FormatException>(action);
        }
    }
}
