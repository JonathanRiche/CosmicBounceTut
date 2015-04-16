using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour 
{
    public Transform follow;
    public float followRate = 0.2F;
    public Vector3 offset = new Vector3(-16F, 0, 0);

	private void Update() 
    {
	    transform.position = Vector3.Lerp(transform.position, follow.position + offset, Time.deltaTime*followRate);
	}
}
