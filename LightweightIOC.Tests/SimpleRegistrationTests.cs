using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightweightIOC.Contract;
using LightweightIOC.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightweightIOC.Tests
{
	[TestClass]
	public class SimpleRegistrationTests
	{
		[TestMethod]
		public void RegisterSimpleType()
		{
			IDIContainer sut = new DIContainer();

			sut.Register(typeof(ITest), typeof(TestImpl));
		}

		[TestMethod]
		public void RegisterConstructorInjection()
		{
			IDIContainer sut = new DIContainer();

			sut.Register(typeof(ITest), typeof(TestImpl));
			sut.Register(typeof(IContract), typeof(ContractImpl));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RegisterConstructorInjection_Fail()
		{
			IDIContainer sut = new DIContainer();

			sut.Register(typeof(IContract), typeof(ContractImpl));
		}

		[TestMethod]
		public void RegisterSimpleType_T()
		{
			IDIContainer sut = new DIContainer();

			sut.Register<ITest, TestImpl>();
		}

		[TestMethod]
		public void RegisterConstructorInjection_T()
		{
			IDIContainer sut = new DIContainer();

			sut.Register<ITest, TestImpl>();
			sut.Register<IContract, ContractImpl>();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RegisterConstructorInjection_Fail_T()
		{
			IDIContainer sut = new DIContainer();

			sut.Register<IContract, ContractImpl>();
		}
	}
}
