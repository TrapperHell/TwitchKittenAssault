using UnityEngine;

/// <summary>
/// Generates non-uniform random numbers.
/// </summary>
public class RandomNumbers : Singleton <RandomNumbers>
{
	#region Methods

	/// <summary>
	/// Gaussian number based on the defined normal distribution curve.
	/// </summary>
	private float GaussianBase(float mean, float standardDeviation)
	{
		float v1;
		float v2;
		float s;

		do
		{
			v1 = 2.0f * Random.Range(0f,1f) - 1.0f;
			v2 = 2.0f * Random.Range(0f,1f) - 1.0f;
			s = v1 * v1 + v2 * v2;
		} while (s >= 1.0f || s == 0f);
		
		s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);

		return mean + (v1 * s * standardDeviation); //NOTE: v1 * s = Gaussian number between -1 and 1
	}

	/// <summary>
	/// Gaussian number based on the defined normal distribution curve. If rejectExtremes is true, values beyond 3.5 standard deviations (i.e. ~0.1% of the sampled points) are rejected.
	/// NOTE: values are NOT clamped at max/min...out-of-range values are just rejected.
	/// </summary>
	public float Gaussian(float mean, float standardDeviation, bool rejectExtremes)
	{
		if (rejectExtremes)
		{
			return Gaussian(mean, standardDeviation, mean - (standardDeviation * 3.5f), mean + (standardDeviation * 3.5f));
		}
		else
		{
			return GaussianBase(mean, standardDeviation);
		}
	}

	/// <summary>
	/// Gaussian number between max and min based on the defined normal distribution curve.
	/// NOTE: values are NOT clamped at max/min...out-of-range values are just rejected.
	/// </summary>
	public float Gaussian(float mean, float standardDeviation, float min, float max)
	{
		float x;
		do
		{
			x = GaussianBase(mean, standardDeviation);
		} while (x < min || x > max);

		return x;
	}

	/// <summary>
	/// Gaussian number between max and min based on a normal distribution curve such that min and max are at 3.5 deviations from the mean (half-way of min and max). This should result in less than ~0.1% rejections (out-of-range).
	/// NOTE: values are NOT clamped at max/min...out-of-range values are just rejected.
	/// </summary>
	public float Gaussian(float min, float max)
	{
		float deviations = 3.5f;
		float range = (max - min) / 2.0f;

		float x;
		do
		{
			x = GaussianBase(min + range, range / deviations);
		} while (x < min || x > max);

		return x;
	}

	#endregion
}
