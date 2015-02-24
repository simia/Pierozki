using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiTimer : MonoBehaviour {

	PlayerController pc;
	LevelCreator lc;


	private Text time;
	private Text distance;

	// Use this for initialization
	void Start () {
		pc = FindObjectOfType (typeof(PlayerController)) as PlayerController;
		lc = FindObjectOfType (typeof(LevelCreator)) as LevelCreator;
		Text[] texts = gameObject.GetComponentsInChildren<Text> ();
		print (texts);
		foreach(Text t in texts)
		{
			print (t.name);
			if(t.name == "Distance")
			{
				distance = t;
			}
			if(t.name == "Time")
			{
				time = t;
			}			
		}
	}
	
	// Update is called once per frame
	void Update () {

		distance.text = "Distance Left:\n" + (lc.LevelLength-1).ToString();
		time.text = "DTime Left:\n" + pc.TimeToCheckpoint.ToString ();

		//gameObject.GetComponent().text = "Time Left:\n" + pc.TimeToCheckpoint.ToString();
	}
}
