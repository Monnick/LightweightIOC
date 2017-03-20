using System;
using System.IO;

namespace LightweightIOC.Configuration
{
	public sealed class Register
	{
		public string Contract { get; set; }

		private Type _contractType = null;
		public Type ContractType
		{
			get { return _contractType ?? (_contractType = ResolveContract()); }
			private set { _contractType = value; }
		}

		public string Implementation { get; set; }

		private Type _implemetationType = null;
		public Type ImplementationType
		{
			get { return _implemetationType ?? (_implemetationType = ResolveImplementation()); }
			private set { _implemetationType = value; }
		}

		public Type ResolveContract()
		{
			return Type.GetType(Contract, true);
		}

		public Type ResolveImplementation()
		{
			return Type.GetType(Implementation, true);
		}

		public void Verify()
		{
			if (ContractType == null)
				throw new FileNotFoundException(string.Format("contract not found ({0})", Contract));

			if (ImplementationType == null)
				throw new FileNotFoundException(string.Format("implementation not found ({0})", Implementation));
		}
	}
}
