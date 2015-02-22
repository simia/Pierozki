using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelCreator : MonoBehaviour {

	public Transform levelBlock;
	public Transform levelBlock2;

	private float creationDelay = 0;
	// Use this for initialization
	List<Transform> blocks = new List<Transform>();
	Vector3 blockPost = new Vector3 (0, 0, 0);

	void Start () {

		for(int i = 1; i <= 35; i++)
		{
			Transform o1 = (Transform)Instantiate(levelBlock, blockPost, Quaternion.identity);
			blocks.Add(o1);
			blockPost.z++;
			Transform o2 = (Transform)Instantiate(levelBlock2, blockPost, Quaternion.identity);
			blocks.Add(o2);
			blockPost.z++;

		}
	}
	
	// Update is called once per frame
	void Update () {
		creationDelay += Time.deltaTime;
		if(creationDelay >= 0.2)
		{
			//for(int i = 0; i <2; i++)
			//{
				Destroy(blocks[0].gameObject);
				blocks.RemoveAt(0);
				blocks.Add((Transform)Instantiate(levelBlock2, blockPost, Quaternion.identity));
				blockPost.z++;
				creationDelay -= 0.2f;
			//}
		}
	}
}
