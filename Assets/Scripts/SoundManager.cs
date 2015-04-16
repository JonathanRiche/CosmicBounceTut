using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private bool soundTrigger = false;

	private AudioSource thisAudioSource;
	private AudioClip currentClip;

	[Header("Set The Size and Audio Clips here")]
	public AudioClip[] soundList;

	// Use this for initialization
	void Start () 
	{
		thisAudioSource = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Breakable")
		{
			currentClip = soundList[1];
		}
		thisAudioSource.clip = currentClip;
		thisAudioSource.Play();
	}

	void ResetTrigger ()
	{
		soundTrigger = false;
	}

	void OnCollisionEnter(Collision other)
	{
		if (!soundTrigger)
		{	
			if (other.gameObject.tag == "NonBreakable")
			{
				currentClip = soundList[0];
			}

			if (other.gameObject.tag == "DontTouch")
			{
				currentClip = soundList[2];
			}
		}
		if (other.gameObject.tag == "Barrier")
		{
			if (this.GetComponent<GamePlayManager>().openBarrier)
			{
				currentClip = soundList[3];
				Invoke("ResetTrigger",3);
			}
			else
				currentClip = soundList[0];
		}

		thisAudioSource.clip = currentClip;
		thisAudioSource.Play();
	}


}
