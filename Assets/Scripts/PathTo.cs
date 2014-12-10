using UnityEngine;
using System.Collections;

public class PathTo : MonoBehaviour 
{
	public GameObject mouseManager;

	private ClickData clickData;
	private Vector3 mousePoint;

	void Awake()
	{
		clickData = mouseManager.GetComponent<ClickData>();
	}

	void Update()
	{
		if(mousePoint != clickData.mousePoint)
		{
			mousePoint = clickData.mousePoint;
			transform.position = mousePoint + new Vector3( 0.0f, 1.0f, 0.0f);
		}
	}
}
