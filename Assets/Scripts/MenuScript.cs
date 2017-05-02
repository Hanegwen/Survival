using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void EndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
