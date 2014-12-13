using UnityEngine;
using System.Collections;

public class PathTo : MonoBehaviour 
{
	public GameObject mouseManager;

	private float speed = 1.0f;
	private ClickData clickData;
	private Vector3 mousePoint;

	void Awake()
	{
		clickData = mouseManager.GetComponent<ClickData>();
	}

	void Update()
	{
		if(transform.position != clickData.mousePoint + new Vector3(0.0f, 1.0f, 0.0f))
		{
			transform.position = new Vector3(Mathf.Lerp(transform.position.x, clickData.mousePoint.x, speed * Time.deltaTime),
		                                 	Mathf.Lerp(transform.position.y, clickData.mousePoint.y + 1.0f, speed * Time.deltaTime),
		                                	Mathf.Lerp(transform.position.z, clickData.mousePoint.z, speed * Time.deltaTime));

		}
	}
}