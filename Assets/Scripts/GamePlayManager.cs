using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour {

	[Header("Set in Inspector")]
	public Text scoreText;

	public Text gameOverText;

	public Text winText;

	public GameObject endGameContainer;
	public GameObject hpcContainer;
	public GameObject barrier;
	public GameObject barrierParticle;
	public AudioSource gameSongContainer;
	public AudioClip[] EndGameClip;

	private Image[] lives;

	[Header("Set The Size Dependant on Amount of Menu Buttons")]
	public Button[] menuButtons;

	//Grab Acess to the Controls Script
	public Controls cont;

	private int score;
	private int hp = 10;
	private int counter;

	[HideInInspector]public bool gameOver = false;
	private bool canWin = false;
	public bool openBarrier = false;
	private bool EndClip = true;

	private float winPercent = DifficultySettings.scoreToBeat;

	// Use this for initialization
	void Start () 
	{
		Initialize();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateGui();

		if (hp <= 0)
		{
			GameOver();
		}

		Winner();
	}


	void Initialize()
	{

		int childCounter = 0;

		counter = hpcContainer.transform.childCount;

		lives = new Image[counter];

		foreach(Transform child in hpcContainer.transform)
		{
			lives[childCounter] = child.GetComponent<Image>();
			childCounter++;
		}

		menuButtons[0].onClick.AddListener(() => {Restart();});
		menuButtons[1].onClick.AddListener(() => {Quit();});


	}

	void TakeDamage(int num)
	{
		lives[num].gameObject.SetActive(false);
	}

	void OnCollisionEnter(Collision coll)
	{

		if (coll.gameObject.tag == "DontTouch")
		{
			hp--;
			TakeDamage(hp);
			coll.gameObject.SendMessage("ShowParticles");
		}

		if (coll.gameObject.tag == "Finish")
			canWin = true;

		if (coll.gameObject.tag == "Barrier")
		{
			if (openBarrier)
				StartCoroutine(BreakBarrier());
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Breakable")
		{
			Destroy(other.gameObject);
			score++;
		}
	}

	void UpdateGui()
	{
		scoreText.text = score.ToString();

	}

	IEnumerator BreakBarrier ()
	{
		barrierParticle.SetActive(true);
		barrier.SetActive(false);
		yield return new WaitForSeconds(1f);
		barrierParticle.SetActive(false);
	}


	void Winner()
	{
		float scoreRef = (float)score;
		float counterRef = 30;

		if (scoreRef/counterRef > winPercent)
		{

			openBarrier = true;

			if (canWin)
			{
				winText.gameObject.SetActive(true);
				gameSongContainer.loop = false;
				gameSongContainer.clip = EndGameClip[1];
				Reload();
			}
		}
	}

	void Quit()
	{
		Application.LoadLevel("Menu");
	}

	void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	void GameOver()
	{
		gameOverText.gameObject.SetActive(true);
		gameSongContainer.loop = false;
		gameSongContainer.clip = EndGameClip[0];
		Reload();

	}

	void PlayEndClip ()
	{
		EndClip = false;
		gameSongContainer.Play();
	}

	void Reload()
	{
		if (EndClip)
			PlayEndClip();

		this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
		gameOver = true;
		endGameContainer.SetActive(true);
		cont.GetComponent<Controls>().enabled = false;
	}
}
