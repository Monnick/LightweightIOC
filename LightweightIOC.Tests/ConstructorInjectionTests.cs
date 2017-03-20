using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightweightIOC.Contract;
using LightweightIOC.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightweightIOC.Tests
{
	[TestClass]
	public class ConstructorInjectionTests
	{
		[TestMethod]
		public void SuccessfullConstructorInjection()
		{
			IDIContainer sut = new DIContainer();
			sut.Register(typeof(ITest), typeof(TestImpl));
			sut.Register(typeof(IContract), typeof(ContractImpl));

			object result = sut.Resolve(typeof(IContract));

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(ContractImpl));
			Assert.IsInstanceOfType(((IContract)result).GetIntern(), typeof(TestImpl));
		}

		[TestMethod]
		public void SuccessfullConstructorInjection_T()
		{
			IDIContainer sut = new DIContainer();
			sut.Register<ITest, TestImpl>();
			sut.Register<IContract, ContractImpl>();

			object result = sut.Resolve<IContract>();

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(ContractImpl));
			Assert.IsInstanceOfType(((IContract)result).GetIntern(), typeof(TestImpl));
		}
	}
}
