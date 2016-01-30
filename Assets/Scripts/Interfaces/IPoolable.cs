/// <summary>
/// Tags an object as a pool-able object. IPoolable objects may be pooled for reuse.
/// </summary>
public interface IPoolable
{
	/// <summary>
	/// Notifies a pooled object that it is about to be reused, providing optional data so that the
	/// object can reset its internal state.
	/// </summary>
	/// <param name="data">Generic object which determines the necessary reset parameters.</param>
	void Consume(IPoolData data);

	/// <summary>
	/// Notifies the object that it is about to be returned into a pool.
	/// </summary>
	void Release();

}