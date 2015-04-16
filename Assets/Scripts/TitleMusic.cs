using UnityEngine;
using System.Collections;

public class TitleMusic : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Application.loadedLevel != 2)
			DontDestroyOnLoad(this.gameObject);
		else
			Destroy(this.gameObject);
	}
}
