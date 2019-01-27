using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick 1 button " + i.ToString()))
            {
                // do something
                print("joystick 1 button " + i.ToString());

            }
        }
    }
}
