using UnityEngine;
using System.Collections;

public class ObstacleMover : MonoBehaviour {

	private Vector3 initPos;
	private Vector3 targetPos;
	private Vector3 currentPos;

	private bool trigger = true;

	[Range(-10,10)]public int offset = 1;

	[Range(1,10)]public float speed;

	public enum Direction 
	{
		vertical,
		horizontal
	};

	public Direction currentDir;

	// Use this for initialization
	void Start () 
	{
		initPos = this.gameObject.transform.position;


		if (currentDir == Direction.vertical)
			targetPos = new Vector3(initPos.x,initPos.y + offset,initPos.z );
		else
			targetPos = new Vector3(initPos.x,initPos.y,initPos.z + offset);

	}
	
	// Update is called once per frame
	void Update () 
	{
		currentPos = this.gameObject.transform.position;

		if (currentPos == targetPos)
			trigger = false;
		if (currentPos == initPos)
			trigger = true;

		Move();

	}

	void Move()
	{
		if (trigger)
			this.gameObject.transform.position = Vector3.MoveTowards(currentPos,targetPos,speed*Time.deltaTime);
		if (trigger != true)
			this.gameObject.transform.position = Vector3.MoveTowards(currentPos,initPos,speed*Time.deltaTime);
	}





}
