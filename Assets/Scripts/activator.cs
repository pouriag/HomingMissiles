using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject foxy;
    public GameObject spanky;
    public GameObject hottie;
    public GameObject bumpkin;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gc = GameObject.Find("GameControls");
        foreach (KeyValuePair<string, int> pair in gc.GetComponent<DontDestroy>().idList)
        {
            switch (pair.Key)
            {
                case "Foxy":
                    foxy.SetActive(true);
                    foxy.GetComponent<PlayerScript>().setId(pair.Value);
                    break;
                case "Spanky":
                    spanky.SetActive(true);
                    spanky.GetComponent<PlayerScript>().setId(pair.Value);
                    break;
                case "Hottie":
                    hottie.SetActive(true);
                    hottie.GetComponent<PlayerScript>().setId(pair.Value);
                    break;
                case "Bumpkin":
                    bumpkin.SetActive(true);
                    bumpkin.GetComponent<PlayerScript>().setId(pair.Value);
                    break;

            }

        }
    }
}
