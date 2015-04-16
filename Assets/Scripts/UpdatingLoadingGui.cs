using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdatingLoadingGui : MonoBehaviour {


	public Text colText;

	private float scoreRef;

	// Use this for initialization
	void Start () 
	{
		scoreRef = DifficultySettings.scoreToBeat * 30;
		colText.text = scoreRef.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
