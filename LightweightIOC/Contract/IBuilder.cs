using System;
using System.Collections.Generic;

namespace LightweightIOC.Contract
{
	/// <summary>
	/// Contains the resolving algorithm.
	/// </summary>
	public interface IBuilder
	{
		/// <summary>
		/// Registers a type and the needed parameters to construct it.
		/// </summary>
		/// <param name="type">The concrete implemenation class.</param>
		/// <param name="parameters">All needed parameters to construct the class.</param>
		void Register(Type type, IEnumerable<IBuilder> parameters);

		/// <summary>
		/// Resolves and constructs the implementation of an interface.
		/// </summary>
		/// <returns>The concrete class.</returns>
		object Get();
	}
}
