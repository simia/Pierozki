using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class LevelCreator : MonoBehaviour {

	public Transform levelBlock;
	public Transform levelBlock2;

	private float creationDelay = 0;
	private System.Random rnd = new System.Random();
	// Use this for initialization
	List<Transform> blocks = new List<Transform>();
	Vector3 blockPost = new Vector3 (0, 0, 0);

	void Start () {

		for(int i = 1; i <= 35; i++)
		{
			Transform o1 = (Transform)Instantiate(levelBlock, blockPost, Quaternion.identity);
			blocks.Add(o1);
			blockPost.z++;
			//Transform o2 = (Transform)Instantiate(levelBlock2, blockPost, Quaternion.identity);
			//blocks.Add(o2);
			//blockPost.z++;

		}
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController pc = FindObjectOfType (typeof(PlayerController)) as PlayerController;
		creationDelay += Time.deltaTime;
		if(creationDelay >= 1f/pc.Speed)
		{
			//for(int i = 0; i <2; i++)
			//{
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
			//}
		}
	}
}
