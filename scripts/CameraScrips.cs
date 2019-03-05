using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrips : MonoBehaviour {

	Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,player.position.y,transform.position.z);
	}
}
