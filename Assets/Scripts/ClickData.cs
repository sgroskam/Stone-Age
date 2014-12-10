using UnityEngine;
using System.Collections;

public class ClickData : MonoBehaviour 
{

	RaycastHit mouseHit;
	public Vector3 mousePoint = new Vector3(0.0f, 0.0f, 0.0f);
	
	void Update()
	{
		if(Input.GetMouseButtonDown(1))
		{
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(mouseRay, out mouseHit);
			mousePoint = mouseHit.point;
		}
		
		Debug.Log("x: " + mouseHit.point.x + "\tz: " + mouseHit.point.z);
	}
}
