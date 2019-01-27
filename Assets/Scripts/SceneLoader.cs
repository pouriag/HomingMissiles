using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currScene = -1;
    // Use this for initialization
    void Start()
    {
        currScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        GameObject [] missiles = GameObject.FindGameObjectsWithTag("Player");
        if (currScene == 4 && missiles.Length < 1) 
        {
            GameObject.Find("Roads").GetComponent<BackgroundScript>().scrollSpeed = 0;
        }
        
        if (currScene == 0 || currScene == 1)
        {
            StartCoroutine(Wait());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void NextScene()
    {
        currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene + 1);
    }

    public void Quit()
    {
            Application.Quit();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        NextScene();
    }

    
}
