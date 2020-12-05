using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

    public void LoadLv(string LevelName)
    {
        Brick.BreakableBlocks = 0;
        SceneManager.LoadSceneAsync(LevelName);
    }
    public static void LoadNextLv()
    {
        Brick.BreakableBlocks = 0;
        Scene scene = SceneManager.GetActiveScene();
        if ((scene.buildIndex + 1) < (SceneManager.sceneCountInBuildSettings - 2))
        {
            SceneManager.LoadSceneAsync(scene.buildIndex + 1);
        }
        else
        {
            SceneManager.LoadSceneAsync("Win");
        }
    }
    public void QuitRequest()
    {
        Application.Quit();
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
