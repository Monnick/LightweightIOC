using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LightweightIOC.Configuration
{
	public sealed class DIConfiguration : IEnumerable<Register>
	{
		public Register[] Register { get; set; }

		public Register this[int index]
		{
			get { return Register[index]; }
			set { Register[index] = value; }
		}

		public void Verify()
		{
			foreach (var reg in Register)
			{
				reg.Verify();
			}
		}

		/// <summary>
		/// Checks if the contract type is registered
		/// </summary>
		/// <param name="contract"></param>
		/// <returns></returns>
		public bool IsRegistered(Type contract)
		{
			return Register != null && Register.Any(r => r.ContractType == contract);
		}

		public IEnumerator<Register> GetEnumerator()
		{
			return Register.AsEnumerable().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
