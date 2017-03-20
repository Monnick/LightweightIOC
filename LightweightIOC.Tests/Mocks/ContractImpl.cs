namespace LightweightIOC.Tests.Mocks
{
	public class ContractImpl : IContract
	{
		private ITest _test;

		public ITest GetIntern()
		{
			return _test;
		}

		public ContractImpl(ITest test)
		{
			_test = test;
		}
	}
}