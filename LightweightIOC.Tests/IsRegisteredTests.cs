using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightweightIOC.Configuration;
using LightweightIOC.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightweightIOC.Tests
{
	[TestClass]
    public class IsRegisteredTests
	{
		[TestMethod]
		public void IsRegistered_True()
		{
			DIConfiguration sut = new DIConfiguration();
			sut.Register = new Register[1];
			sut.Register[0] = new Register();
			sut.Register[0].Contract = "LightweightIOC.Tests.Mocks.ITest, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";
			sut.Register[0].Implementation = "LightweightIOC.Tests.Mocks.TestImpl, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";

			Assert.IsTrue(sut.IsRegistered(typeof(ITest)));
		}

		[TestMethod]
		public void IsRegistered_False()
		{
			DIConfiguration sut = new DIConfiguration();
			sut.Register = new Register[1];
			sut.Register[0] = new Register();
			sut.Register[0].Contract = "LightweightIOC.Tests.Mocks.ITest, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";
			sut.Register[0].Implementation = "LightweightIOC.Tests.Mocks.TestImpl, LightweightIOC.Tests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";

			Assert.IsFalse(sut.IsRegistered(typeof(IServiceProvider)));
		}
	}
}
