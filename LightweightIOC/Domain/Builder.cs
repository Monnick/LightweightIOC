using LightweightIOC.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LightweightIOC.Domain
{
	class Builder : IBuilder
	{
		private Type _type;
		private Func<object>[] _parameters;

		public Builder()
		{
		}

		public void Register(Type type, IEnumerable<IBuilder> parameters)
		{
			_type = type;
			_parameters = parameters.Select<IBuilder, Func<object>>(p => p.Get).ToArray();
		}

		public object Get()
		{
			return Activator.CreateInstance(_type, _parameters.Select(p => p()).ToArray());
		}
	}
}
