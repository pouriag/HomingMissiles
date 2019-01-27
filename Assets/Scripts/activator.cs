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
    void Awake()
    {
        GameObject gc = GameObject.Find("GameControls");
        foreach (KeyValuePair<string, int> pair in gc.GetComponent<DontDestroy>().idList)
        {
            switch (pair.Key)
            {
                case "Foxy":
                    foxy.transform.GetChild(0).gameObject.SetActive(true);
                    foxy.GetComponent<PlayerScript>().setId(pair.Value);
                    break;
                case "Spanky":
                    spanky.transform.GetChild(0).gameObject.SetActive(true);
                    spanky.GetComponent<PlayerScript>().setId(pair.Value);
                    break;
                case "Hottie":
                    hottie.transform.GetChild(0).gameObject.SetActive(true);
                    hottie.GetComponent<PlayerScript>().setId(pair.Value);
                    break;
                case "Bumpkin":
                    bumpkin.transform.GetChild(0).gameObject.SetActive(true);
                    bumpkin.GetComponent<PlayerScript>().setId(pair.Value);
                    break;

            }

        }
    }
}
