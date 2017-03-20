using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightweightIOC.Contract;
using LightweightIOC.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightweightIOC.Tests
{
	[TestClass]
	public class KeyOverrideTests
	{
		[TestMethod]
		public void KeyOverrideSimple_Allowed()
		{
			IDIContainer sut = new DIContainer();
			sut.Register<int, TestImpl>();

			object result = sut.Resolve(typeof(int));

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(TestImpl));
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void KeyOverrideSimple_NotAllowed()
		{
			IDIContainer sut = new DIContainer();
			sut.Register<int, TestImpl>();

			sut.Resolve<int>();
		}
	}
}
