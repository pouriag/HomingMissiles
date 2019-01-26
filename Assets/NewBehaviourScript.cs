using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //for (int i = 0; i < 20;i++){
        //    if (Input.GetKeyDown("joystick 1 button " + i))
        //    {
        //        Debug.Log("joystick 1 button " + i);
        //    }
        //}

        if (Input.GetKeyDown("joystick 1 button 13"))
        {
            print("FIRE!!!");
        }


    }
}
