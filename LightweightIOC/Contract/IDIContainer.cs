using System;

namespace LightweightIOC.Contract
{
	/// <summary>
	/// Contains all registered interfaces and their concrete implementation.
	/// </summary>
	public interface IDIContainer
	{
		/// <summary>
		/// Registers an interface to its implementation.
		/// </summary>
		/// <param name="contract">The interface to resolve in the future.</param>
		/// <param name="implementation">The concrete implementation class.</param>
		void Register(Type contract, Type implementation);

		/// <summary>
		/// Registers an interface to its implementation.
		/// </summary>
		/// <typeparam name="TContract">The interface to resolve in the future.</typeparam>
		/// <typeparam name="TImplementation">The concrete implementation class.</typeparam>
		void Register<TContract, TImplementation>();

		/// <summary>
		/// Reads a configuration and registers all interfaces and classes.
		/// </summary>
		/// <param name="configuration">The configuration object.</param>
		void ReadConfiguration(Configuration.DIConfiguration configuration);

		/// <summary>
		/// Resolves an interface to an implementation class.
		/// </summary>
		/// <param name="contract">The interface to resolve.</param>
		/// <returns>The registered class.</returns>
		object Resolve(Type contract);

		/// <summary>
		/// Resolves an interface to an implementation class.
		/// </summary>
		/// <typeparam name="TContract">The interface to resolve.</typeparam>
		/// <returns>The registered class.</returns>
		TContract Resolve<TContract>();
	}
}
