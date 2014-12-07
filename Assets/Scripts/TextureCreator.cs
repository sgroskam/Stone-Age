using UnityEngine;
using System.Collections;

public class TextureCreator : MonoBehaviour 
{
	[Range(2, 512)]
	public int resolution = 256;
	[Range(1, 3)]
	public int dimensions = 3;
	public float frequency = 128.0f;
	public NoiseMethodType type;
	private Texture2D texture;

	private void OnEnable()
	{
		if(texture == null)
		{
			texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, false);
			texture.name = "Procedural Texture";
			texture.wrapMode = TextureWrapMode.Clamp;
			texture.filterMode = FilterMode.Trilinear;
			texture.anisoLevel = 9;
			GetComponent<MeshRenderer>().material.mainTexture = texture;
		}
		FillTexture();
	}

	private void Update()
	{
		if(transform.hasChanged)
		{
			transform.hasChanged = false;
			FillTexture();
		}
	}

	public void FillTexture()
	{
		if(texture.width != resolution)
		{
			texture.Resize(resolution, resolution);
		}

		//pointxy; 0 is left or bottom; 1 is right or top.
		Vector3 point00 = transform.TransformPoint( new Vector3(-0.5f, -0.5f));
		Vector3 point01 = transform.TransformPoint(new Vector3(-0.5f, 0.5f));
		Vector3 point10 = transform.TransformPoint(new Vector3(0.5f, -0.5f));
		Vector3 point11 = transform.TransformPoint(new Vector3(0.5f, 0.5f));

		NoiseMethod method = Noise.noiseMethods[(int) type][dimensions-1];

		float stepSize = 1.0f / resolution;

		for(int y = 0; y < resolution; y++)
		{
			//Find the left and right edges.
			Vector3 point0 = Vector3.Lerp( point00, point01, (( y + 0.5f) * stepSize));
			Vector3 point1 = Vector3.Lerp( point10, point11, (( y + 0.5f) * stepSize));

			for(int x = 0; x < resolution; x++)
			{
				//cycle through points in each row of the texture.
				Vector3 point = Vector3.Lerp( point0, point1, ( x + 0.5f) * stepSize);

				float sample = method( point, frequency);
				if( type != NoiseMethodType.Value)
				{
					sample = sample * 0.5f + 0.5f;
				}

				texture.SetPixel( x, y, Color.white * sample);
			}
		}
		texture.Apply();
	}


}
