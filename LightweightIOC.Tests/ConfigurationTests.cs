using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightweightIOC.Configuration;
using LightweightIOC.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightweightIOC.Tests
{
	[TestClass]
    public class ConfigurationTests
	{
		[TestMethod]
		public void ConfigurationTypesResolve()
		{
			Register sut = new Register();
			sut.Contract = "LightweightIOC.Tests.Mocks.ITest, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";
			sut.Implementation = "LightweightIOC.Tests.Mocks.TestImpl, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";

			Assert.AreEqual(typeof(ITest), sut.ResolveContract());
			Assert.AreEqual(typeof(TestImpl), sut.ResolveImplementation());
		}

		[TestMethod]
		public void ConfigurationResolveCreation_Simple()
		{
			DIContainer sut = new DIContainer();
			DIConfiguration config = new DIConfiguration();
			config.Register = new Register[1];
			config.Register[0] = new Register();
			config.Register[0].Contract = "LightweightIOC.Tests.Mocks.ITest, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";
			config.Register[0].Implementation = "LightweightIOC.Tests.Mocks.TestImpl, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";

			sut.ReadConfiguration(config);
			object result = sut.Resolve(typeof(ITest));

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(TestImpl));
		}

		[TestMethod]
		public void ConfigurationVerify_SimpleOK()
		{
			Register sut = new Register();
			sut.Contract = "LightweightIOC.Tests.Mocks.ITest, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";
			sut.Implementation = "LightweightIOC.Tests.Mocks.TestImpl, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";

			sut.Verify();
		}

		[TestMethod]
		[ExpectedException(typeof(TypeLoadException))]
		public void ConfigurationVerify_SimpleFail()
		{
			Register sut = new Register();
			sut.Contract = "LightweightIOC.Tests.Mocks.ITesting, LightweightIOC.Tests";
			sut.Implementation = "LightweightIOC.Tests.Mocks.TestImpling, LightweightIOC.Tests";

			sut.Verify();
		}

		[TestMethod]
		public void ConfigurationVerify_ComplexOK()
		{
			DIConfiguration sut = new DIConfiguration();
			sut.Register = new Register[1];
			sut.Register[0] = new Register();
			sut.Register[0].Contract = "LightweightIOC.Tests.Mocks.ITest, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";
			sut.Register[0].Implementation = "LightweightIOC.Tests.Mocks.TestImpl, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";

			sut.Verify();
		}

		[TestMethod]
		[ExpectedException(typeof(TypeLoadException))]
		public void ConfigurationVerify_ComplexFail()
		{
			DIConfiguration sut = new DIConfiguration();
			sut.Register = new Register[1];
			sut.Register[0] = new Register();
			sut.Register[0].Contract = "LightweightIOC.Tests.Mocks.ITesting, LightweightIOC.Tests";
			sut.Register[0].Implementation = "LightweightIOC.Tests.Mocks.TestImpling, LightweightIOC.Tests";

			sut.Verify();
		}
	}
}
