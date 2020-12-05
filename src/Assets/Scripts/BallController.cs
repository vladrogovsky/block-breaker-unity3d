using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    private PlayerControl parentPaddle;
    private Vector3 paddleToBallVect;
    private bool StartGame = false;
    public int maxYspeed = 12;
    public int maxXspeed = 5;
    public int minXspeed = 1;

    void Start () {
        parentPaddle = GameObject.FindObjectOfType<PlayerControl>();
        paddleToBallVect = this.transform.position-parentPaddle.transform.position;
	}
    public void StartAutoGame()
    {
        StartGame = true;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (StartGame)
        {
            this.GetComponent<AudioSource>().Play();
            int multiplayerX = (this.GetComponent<Rigidbody2D>().velocity.x > 0) ? 1 : -1;
            int multiplayerY = (this.GetComponent<Rigidbody2D>().velocity.y > 0) ? 1 : -1;
            //Vector2 newVelocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x+Random.Range(0.1f, 0.7f), maxYspeed*multiplayerY);
            /*
             if (Mathf.Abs(newVelocity.x)>maxXspeed)
            {
                newVelocity.x = maxXspeed * multiplayerX;
            }
             */
            Vector2 newVelocity = new Vector2(Random.Range(minXspeed, maxXspeed)*multiplayerX, maxYspeed*multiplayerY);
            this.GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0) && !StartGame)
        {
            StartGame = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
        if (!StartGame)
        {
            this.transform.position = parentPaddle.transform.position + paddleToBallVect;
        }
        
	}
}
