using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Background")
        {
            other.transform.position = new Vector3(17.7f, 0f, 0f);
        }
    }
}
