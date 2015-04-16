using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	[SerializeField]private GameObject[] checkList;

	private float difRef;

	public void StartGame()
    {
        Application.LoadLevel(1);
    }

	public void SetDifficulty(float dif)
	{
		DifficultySettings.scoreToBeat = dif;
		Debug.Log("Player now has to collect " + dif*100 + "% of orbs");
	}


	void Start ()
	{
		//Drag an Drop in inspector could interfere with buttons, set here for good measure
		checkList = new GameObject[3];
		checkList[0] = GameObject.Find("Check0");
		checkList[1] = GameObject.Find("Check1");
		checkList[2] = GameObject.Find("Check2");
	}

	void Update()
	{
		difRef = DifficultySettings.scoreToBeat;


		if (difRef == 0.5f)
		{Check(0); DifficultySettings.difficultyName ="Beginner";}
		else if (difRef == 0.7f)
		{Check(1); DifficultySettings.difficultyName ="Challenging";}
		else 
		{Check(2); DifficultySettings.difficultyName ="Insane";}
	}
	 

	void Check (int num)
	{

		foreach (GameObject check in checkList)
		{
			if (check.activeSelf)
				check.SetActive(false);
		}

		checkList[num].SetActive(true);
	}
}
