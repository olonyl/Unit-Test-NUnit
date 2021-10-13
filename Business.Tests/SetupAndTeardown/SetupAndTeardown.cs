using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

[SetUpFixture]
public class SetupAndTeardown
{
    [OneTimeSetUp]
    public void AssemblySetup()
    {
        Trace.WriteLine("Assembly setup.");
    }
    [OneTimeTearDown]
    public void AssemblyTeardown()
    {
        Trace.WriteLine("Assembly teardown.");
    }
}

namespace Business.Tests.SetupAndTeardown
{
    [SetUpFixture]
    public class NamespaceSetupAndTeardown
    {
        [OneTimeSetUp]
        public void NamespaceSetup()
        {
            Trace.WriteLine("Namespace setup.");
        }
        [OneTimeTearDown]
        public void NamespaceTeardown()
        {
            Trace.WriteLine("Namespace teardown.");
        }
    }
}
