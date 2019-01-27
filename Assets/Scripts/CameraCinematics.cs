using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCinematics : MonoBehaviour
{
    public List<GameObject> missiles;
    public AudioClip music;

    void Awake()
    {
        GameObject.FindObjectOfType<BackgroundScript>().scrollSpeed = 0f;
        transform.position = new Vector3(-7.26f, -14.7f, -7.4f);
        transform.rotation = Quaternion.Euler(-71.44f, 0f, 0f);
        GetComponent<Camera>().fieldOfView = 5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject m in missiles)
        {
            m.GetComponentInChildren<Animator>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -4.7f)
        {
            float deltaZ = Time.deltaTime;
            float newZ = transform.position.z + deltaZ;

            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
        }
        else
        {
            transform.position = new Vector3(-4.64f, 0.8f, -3.74f);
            transform.rotation = Quaternion.Euler(6.842f, -40.935f, -959.4f);
            GetComponent<Camera>().fieldOfView = 65f;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        transform.position = new Vector3(0f, 0f, -10f);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        foreach (GameObject m in missiles)
        {
            m.GetComponentInChildren<Animator>().enabled = true;
        }
        GetComponent<CameraShake>().enabled = true;
        GameObject.FindObjectOfType<BackgroundScript>().scrollSpeed = 5f;
        //GetComponent<AudioSource>().clip = music;
    }
}
