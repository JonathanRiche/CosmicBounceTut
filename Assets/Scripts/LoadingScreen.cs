using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	private Transform thisContainer;

	private GameObject[] loadingBars;

	private int timeCount;

	private bool ready = false;

	public float loadSpeed;

	// Use this for initialization
	void Start () 
	{
		thisContainer = this.transform;

		Initialize();

		Invoke("Load", loadSpeed);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( timeCount == 6 )
			ready = true;

		if (ready)
			Application.LoadLevel(2);
	}

	void Initialize ()
	{

		int childCount = thisContainer.transform.childCount;

		loadingBars = new GameObject[childCount];

		int counter = 0;

		foreach (Transform child in thisContainer)
		{
			loadingBars[counter] = child.gameObject;
			counter++;
		}
	}

	void Load()
	{
		this.GetComponent<AudioSource>().Play();
		Destroy(loadingBars[timeCount]);
		timeCount++;

		Invoke("Load", loadSpeed);

	}


}
