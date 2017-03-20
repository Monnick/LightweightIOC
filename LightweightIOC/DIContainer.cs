using LightweightIOC.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LightweightIOC
{
	public sealed class DIContainer : IDIContainer
	{
		private Dictionary<Type, IBuilder> _types;

		public DIContainer()
		{
			_types = new Dictionary<Type, IBuilder>();
		}

		public void Register(Type contract, Type implementation)
		{
			_types.Add(contract, CreateBuilder(implementation, implementation.GetConstructors()));
		}

		public void Register<TContract, TImplementation>()
		{
			Register(typeof(TContract), typeof(TImplementation));
		}

		public void ReadConfiguration(Configuration.DIConfiguration configuration)
		{
			foreach (var registration in configuration)
			{
				Register(registration.ResolveContract(), registration.ResolveImplementation());
			}
		}

		/// <summary>
		/// Throws an key not found exception in case of not registered type.
		/// </summary>
		/// <param name="contract"></param>
		/// <returns></returns>
		public object Resolve(Type contract)
		{
			return _types[contract].Get();
		}

		public TContract Resolve<TContract>()
		{
			return (TContract)Resolve(typeof(TContract));
		}

		private IBuilder CreateBuilder(Type type, ConstructorInfo[] constructors)
		{
			// start with the smallest constructor
			foreach (var constructor in constructors.OrderBy(c => c.GetParameters().Length))
			{
				var parameters = constructor.GetParameters();

				if (parameters.All(p => _types.Any(t => t.Key == p.ParameterType)))
				{
					var builder = new Domain.Builder();
					List<IBuilder> builders = new List<IBuilder>();

					for (int i = 0; i < parameters.Length; i++)
					{
						builders.Add(_types.First(t => t.Key == parameters[i].ParameterType).Value);
					}

					builder.Register(type, builders);
					return builder;
				}
			}

			throw new ArgumentException("constructor can not be fullfilled");
		}
	}
}
