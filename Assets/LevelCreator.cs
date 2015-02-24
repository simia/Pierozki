using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class LevelCreator : MonoBehaviour {

	public Transform levelBlock;
	public Transform levelBlock2;

	public Transform checkpoint;

	private float creationDelay = 0;
	private System.Random rnd = new System.Random();
	// Use this for initialization
	List<Transform> blocks = new List<Transform>();
	Vector3 blockPost = new Vector3 (0, 0, 0);

	public int LevelOffset;
	public int LevelLength;

	private bool noCheckpoint = true;
	private PlayerController pc;

	void Start () {
		pc = FindObjectOfType (typeof(PlayerController)) as PlayerController;
		LevelLength -= (int)pc.transform.position.z;
		for(int i = 1; i <= LevelOffset; i++)
		{
			Transform o1 = (Transform)Instantiate(levelBlock, blockPost, Quaternion.identity);
			blocks.Add(o1);
			blockPost.z++;
		}
	}

	private void adjustLevelLength()
	{
		LevelLength--;

	}

	// Update is called once per frame
	void Update () {

		creationDelay += Time.deltaTime;
		if(creationDelay >= 1f/pc.Speed)
		{
			adjustLevelLength();
			if(noCheckpoint && LevelLength < LevelOffset)
			{
				noCheckpoint = false;
				Instantiate(checkpoint, blockPost, Quaternion.identity).name = "Checkpoint";
			}

			Destroy(blocks[0].gameObject);
			blocks.RemoveAt(0);
			if(rnd.Next(5) < 4)
			{
				blocks.Add((Transform)Instantiate(levelBlock, blockPost, Quaternion.identity));
			}
			else
			{
				blocks.Add((Transform)Instantiate(levelBlock2, blockPost, Quaternion.identity));
			}				
			blockPost.z++;
			creationDelay -= 1f/pc.Speed;
		}
	}
}
