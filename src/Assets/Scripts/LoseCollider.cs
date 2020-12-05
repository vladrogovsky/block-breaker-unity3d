using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    private LevelManager levelManager;
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager.LoadLv("Lose");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
//        print("Collision");
    }
    // Use this for initialization
    void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
