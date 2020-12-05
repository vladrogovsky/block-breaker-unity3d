using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public bool autoPlay = false;
    private BallController AutoStart;
    // Use this for initialization
    void Start () {
        AutoStart = GameObject.FindObjectOfType<BallController>();
        if (autoPlay)
        {
            AutoStart.StartAutoGame();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            this.transform.position = new Vector3(GameObject.FindObjectOfType<BallController>().transform.position.x, this.transform.position.y, this.transform.position.z);
        }
	}
    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        float MovePosInBlock = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, 0.5f, 15.5f);// *16 to transform to gain units
        paddlePos.x = MovePosInBlock;
        this.transform.position = paddlePos;
    }
}
