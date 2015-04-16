using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
    public float controlSensitivity = 4F;
	private float rotation = 0;

	[Header("Tweak This Until it Feels Right")]
	[Range(-20,-1)]public float gravityForce;

	private void Update() 
    {
	    if(Input.GetKey(KeyCode.LeftArrow))
            rotation -= controlSensitivity;
        else if(Input.GetKey(KeyCode.RightArrow))
            rotation += controlSensitivity;


        Camera.main.transform.Rotate(0, 0, rotation);
        rotation = 0;

        Physics.gravity = new Vector3(0, gravityForce * Camera.main.transform.up.y, gravityForce * Camera.main.transform.up.z);
	}
}
