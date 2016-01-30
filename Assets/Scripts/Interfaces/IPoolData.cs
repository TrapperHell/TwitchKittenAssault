using UnityEngine;

/// <summary>
/// Interface for pool data classes needed by IPoolable objects.
/// </summary>
public interface IPoolData
{
	/// <summary>
	/// The parent transform of the consumed poolable object
	/// </summary>
	Transform ParentTransform
	{
		get;
	}
	

}