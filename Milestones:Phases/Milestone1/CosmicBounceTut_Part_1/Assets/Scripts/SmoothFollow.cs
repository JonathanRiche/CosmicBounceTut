using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour 
{
	//We set the Object we want the camera to follow in the inspector
	[Header("Set the Ball to be the Target")]
    public Transform target;
   
	//How fast/slow we want the camera to follow the ball
	public float followRate = 0.2F;
    
	//Offets the camera so we can center the ball on the screen
	public Vector3 offset = new Vector3(-16F, 0, 0);

	private void Update() 
    {
		//Every Frame the camera's position is "Updated" to follow the "Target"
	    transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime*followRate);
	}
}
