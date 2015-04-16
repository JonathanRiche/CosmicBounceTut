using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	[Header("Set this for length of Game")]
	public float gameLength = 60f;

	public GameObject player;

	private int timeUi;

	private bool trigger = true;

	// Use this for initialization
	void Start () 
	{
		if (player == null)
			player = GameObject.Find("Ball");
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (gameLength >= 0)
		{
			gameLength -= 1 * Time.deltaTime;

			if (player.GetComponent<GamePlayManager>().gameOver == false)
				this.GetComponent<Text>().text = timeUi.ToString(); 
		}

		timeUi =  Mathf.RoundToInt(gameLength);

		if (gameLength <= 11 && trigger)
		{this.GetComponent<AudioSource>().Play(); trigger=false;}

		if (gameLength <= 0 || player.GetComponent<GamePlayManager>().gameOver)
			this.GetComponent<AudioSource>().Stop();

		if (gameLength <= 0)
		{
			player.SendMessage("GameOver");
		}



	}
}
