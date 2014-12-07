using UnityEngine;
using System.Collections;

public class Noise
{
	private static int[] hash = {0, 1, 2, 3, 4, 5, 6, 7};
	public static float Value( Vector3 point, float frequency)
	{
		point *= frequency;
		int i = Mathf.FloorToInt(point.x);
		i &= 7;
		return hash[i] / 7f;
	}
}
