using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    private int timesHit;
    private int maxHits;
    private bool isBreakable;

    public GameObject Smoke;
    public AudioClip CrackSound;
    public static int BreakableBlocks = 0;
    public Sprite[] hitSprites;
	// Use this for initialization
	void Start () {
        timesHit = 0;
        maxHits = hitSprites.Length+1;
        isBreakable = (this.tag == "BreakableBlock");
        if (isBreakable)
        {
            BreakableBlocks++;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(CrackSound, this.transform.position); // to play even after destruction of the brick
        if (isBreakable)
        {
            HitsHandler();
        }
    }
    void HitsHandler()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            BreakableBlocks--;
            if (BreakableBlocks <= 0)
            {
                LevelManager.LoadNextLv();
            }
            DestoryEffect();
            Destroy(this.gameObject);
        }
        else
        {
            if (hitSprites[timesHit - 1])
            {
                this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
            }
            else
            {
                Debug.LogError("No sprite for brick!");
            }
        }
    }
    void DestoryEffect()
    {
        var SmokeColor = Smoke.GetComponent<ParticleSystem>().main;
        SmokeColor.startColor = this.GetComponent<SpriteRenderer>().color;
        GameObject tempSmoke = Instantiate(Smoke, this.transform.position, Quaternion.identity);
        Destroy(tempSmoke, tempSmoke.GetComponent<ParticleSystem>().main.duration);
    }
    // Update is called once per frame
    void Update () {

	}
}
