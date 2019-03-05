using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour {
	Transform player;
	[SerializeField] float platformGap;
	[SerializeField] float left;
	[SerializeField] float right;
	[SerializeField] float up;
	[SerializeField] Text progressText;
	[SerializeField] GameObject platform;
	GameObject latestRightUp = null; 
	GameObject latestLeftUp = null;
	GameObject latestRightDown = null;
	GameObject latestLeftDown = null;
	

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		InitializePlatforms();
	}
	
	// Update is called once per frame
	void Update () {
		progressText.text = player.position.y.ToString();
		if (latestRightUp != null)
		{
			if (player.position.y + up > latestRightUp.transform.position.y + 6.5f)
			{
				PlacePlatformPairUp();
			}
			if (player.position.y - up < latestRightDown.transform.position.y - 6.5f)
			{
				PlacePlatformPairDown();
			}
		}
	}

	void PlacePlatformPairUp()
	{
		float y = latestRightUp.transform.position.y + Random.Range(5.0f,6.5f);
		float gap = Random.Range(-platformGap,platformGap);
		float x = right + gap;
		// i want to place 2 platforms at the same height accross from eachother. 
		GameObject rightPlat = Instantiate(platform, new Vector3(x,y,0), Quaternion.identity);
		x = left + gap;
		GameObject leftPlat = Instantiate(platform, new Vector3(x,y,0), Quaternion.identity);
		latestRightUp = rightPlat;
		latestLeftUp = leftPlat;
	}
	void PlacePlatformPairDown()
	{
		float y = latestRightDown.transform.position.y - Random.Range(5.0f,6.5f);
		float gap = Random.Range(-platformGap,platformGap);
		float x = right + gap;
		// i want to place 2 platforms at the same height accross from eachother. 
		GameObject rightPlat = Instantiate(platform, new Vector3(x,y,0), Quaternion.identity);
		x = left - gap;
		GameObject leftPlat = Instantiate(platform, new Vector3(x,y,0), Quaternion.identity);
		latestRightDown = rightPlat;
		latestLeftDown = leftPlat;
	}
	void 	InitializePlatforms()
	{
		// place first 2? 
		GameObject rightPlat = Instantiate(platform, new Vector3(14,0,0), Quaternion.identity);
		GameObject leftPlat = Instantiate(platform, new Vector3(-8,0,0), Quaternion.identity);
		latestRightUp = rightPlat;
		latestLeftUp = leftPlat;
		latestRightDown = rightPlat;
		latestLeftDown = leftPlat;
		for (int i = 0; i < 20;i++)
		{
			PlacePlatformPairUp();
			PlacePlatformPairDown();
			// 
		}
	}
	// so we ahve a height above the player that we want to have a platform. If there is not a platform at that height then we will put one there
	// 
}
