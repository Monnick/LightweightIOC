using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightweightIOC.Contract;
using LightweightIOC.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightweightIOC.Tests
{
	[TestClass]
	public class SimpleCreationTests
	{
		[TestMethod]
		public void SimpleCreation()
		{
			IDIContainer sut = new DIContainer();
			sut.Register(typeof(ITest), typeof(TestImpl));

			object result = sut.Resolve(typeof(ITest));

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(TestImpl));
		}

		[TestMethod]
		public void SimpleCreation_double()
		{
			IDIContainer sut = new DIContainer();
			sut.Register(typeof(ITest), typeof(TestImpl));

			object result = sut.Resolve(typeof(ITest));
			object result2 = sut.Resolve(typeof(ITest));

			Assert.IsNotNull(result);
			Assert.IsNotNull(result2);
			Assert.AreNotEqual(result, result2); // two seperate instances
		}

		[TestMethod]
		public void SimpleCreation_T()
		{
			IDIContainer sut = new DIContainer();
			sut.Register<ITest, TestImpl>();

			object result = sut.Resolve<ITest>();

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(TestImpl));
		}

		[TestMethod]
		public void SimpleCreation_double_T()
		{
			IDIContainer sut = new DIContainer();
			sut.Register<ITest, TestImpl>();

			object result = sut.Resolve<ITest>();
			object result2 = sut.Resolve<ITest>();

			Assert.IsNotNull(result);
			Assert.IsNotNull(result2);
			Assert.AreNotEqual(result, result2); // two seperate instances
		}

		[TestMethod]
		[ExpectedException(typeof(KeyNotFoundException))]
		public void SimpleCreation_UnkownContract()
		{
			IDIContainer sut = new DIContainer();

			sut.Resolve<IOther>();
		}
	}
}
