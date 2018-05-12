using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //
        Vector2 tester = GetComponent<SpriteRenderer>().bounds.size;
        GetComponent<EdgeCollider2D>().offset = new Vector2(0.0f, GetComponent<SpriteRenderer>().bounds.size.y * 0.5f / transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
