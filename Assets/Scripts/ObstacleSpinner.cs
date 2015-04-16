using UnityEngine;
using System.Collections;

public class ObstacleSpinner : MonoBehaviour {

	private Vector3 initRot;

	public float spinSpeed =1f;
	public bool isClockwise = true;
	public GameObject particleSys;

	//[HideInInspector]public bool particleTrigger = false;

	// Use this for initialization
	void Start () 
	{
		initRot = this.transform.eulerAngles;

		foreach (Transform child in this.transform)
		{
			if (child != null)
				particleSys = child.gameObject;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isClockwise)
			this.transform.eulerAngles = new Vector3(initRot.x-=spinSpeed,initRot.y,initRot.z);	
		else
			this.transform.eulerAngles = new Vector3(initRot.x+=spinSpeed,initRot.y,initRot.z);	
	}

	IEnumerator ShowParticles()
	{	
		if (particleSys != null)
			particleSys.SetActive(true);

		yield return new WaitForSeconds(.5f);

		if (particleSys != null)
			particleSys.SetActive(false);
	}
}
