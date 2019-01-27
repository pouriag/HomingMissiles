using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    private bool turned = false;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(1, 3);

        if (rand == 2)
        {
            turned = true;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaY = Time.deltaTime;
        float newY;

        if (turned)
        {
            newY = transform.position.y - deltaY;
        }
        else
        {
            newY= transform.position.y + deltaY;
        }

        transform.position = new Vector2(transform.position.x, newY);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border" || other.tag == "Obstacle" || other.tag.StartsWith("Target"))
        {
            turned = turned ? false : true;

            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
