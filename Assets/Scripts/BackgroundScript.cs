using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

    public float scrollSpeed;
    public float timeInterval = 20f;

    private float locStartTime = 0;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);

        if (Time.timeSinceLevelLoad - locStartTime > timeInterval)
        {
            locStartTime = Time.timeSinceLevelLoad;
            scrollSpeed++;
        }
    }
}
