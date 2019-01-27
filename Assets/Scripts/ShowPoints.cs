using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPoints : MonoBehaviour
{
    public Dictionary<int, int> points = new Dictionary<int, int>();
    public Text Spanky;
    public Text Foxy;
    public Text Hottie;
    public Text Bumpkin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Image>().enabled)
        {
            GameObject gc = GameObject.Find("GameControls");
            foreach (KeyValuePair<string, int> pair in gc.GetComponent<DontDestroy>().idList)
            {
                int value = 0;
                switch (pair.Key)
                {
                    case "Foxy":
                        if (points.TryGetValue(pair.Value, out value))
                        {
                            Debug.Log("Foxy");
                            Foxy.text = value.ToString();
                        }
                        break;
                    case "Spanky":
                        if (points.TryGetValue(pair.Value, out value))
                        {
                            Debug.Log("Spanky");
                            Spanky.text = value.ToString();
                        }
                        break;
                    case "Hottie":
                        if (points.TryGetValue(pair.Value, out value))
                        {
                            Debug.Log("Hottie");
                            Hottie.text = value.ToString();
                        }
                        break;
                    case "Bumpkin":
                        if (points.TryGetValue(pair.Value, out value))
                        {
                            Debug.Log("Bumpkin");
                            Bumpkin.text = value.ToString();
                        }
                        break;

                }
            }
        }
    }
}
