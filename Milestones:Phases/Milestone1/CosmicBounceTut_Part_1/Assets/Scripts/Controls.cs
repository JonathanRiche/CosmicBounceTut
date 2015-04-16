using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	//How Sensitive/Fast the camera is
    public float controlSensitivity = 4F;

	//The Value that rotates the camera
	private float rotation = 0;

	//Runs once per frame
	void Update() 
    {
		//Run this entire function every frame
		CameraControls();
	}

	//Rotates the Camera Clockwise or CounterClockwise
	void CameraControls ()
	{
		//If the player presses the left arrow key rotate the camera counter clockwise
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			//Subtract the controlSensitvity value(in this case 4) from the rotation value every frame 
			rotation -= controlSensitivity;
		}
		// Otherwis if the Player Hits the right arrow key rotate the camera clockwise
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			//Adds the controlSensitvity value(in this case 4) to the rotation value every frame 
			rotation += controlSensitivity;
		}

		//Rotate the camera in the Z-axis by the roatation value(0,in the x and 0 in the y axis b/c we only need 1dimension of rotation)
		Camera.main.transform.Rotate(0, 0, rotation);

		//Reset Rotation to 0 so that the camera is not always rotating
		rotation = 0;

		//We use natural 3d physics to move the ball dependant on the direction our Camera is facing, Not necessary to edit this, unless you would
		//Like to change how fast the ball moves
		Physics.gravity = new Vector3(0, -9.81F * Camera.main.transform.up.y, -9.81F * Camera.main.transform.up.z);
	}
}
