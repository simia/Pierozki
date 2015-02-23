using UnityEngine;
using System.Collections;


public class SlowDownTrap : MonoBehaviour, IObstacle {

	// Use this for initialization
	void Start () {
		print ("yello");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DoJob (PlayerController pc)
	{
		print ("slow down");
		pc.ChangeSpeed(2);
	}

}
