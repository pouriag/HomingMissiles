using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    public List<AudioClip> audios;
    public float waitTime = 1f;

    private void Awake()
    {
        GetComponent<AudioSource>().clip = audios[Random.Range(0, audios.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
