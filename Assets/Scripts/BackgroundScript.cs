using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

    public float scrollSpeed;
    public float timeInterval = 20f;

    private int division = 0;
    private float totalTime = 0;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);

        totalTime += Time.deltaTime;

        int newDiv = (int)(totalTime / timeInterval);

        if (newDiv > division)
        {
            division = newDiv;
            scrollSpeed++;
        }
    }
}
