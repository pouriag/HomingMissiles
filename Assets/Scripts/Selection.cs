using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public const float DELAY_TIME = 25000f;
    public string characterName = "";
    public int id ;

    private float moveHorizontal;
    private bool ready = false;
    private bool active = false;
    private float time = DELAY_TIME; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("joystick " + id + " button 4")) {
            active = true;
            gameObject.GetComponent<RawImage>().enabled = true;
        }
        if(active){
            if (!ready)
            {
                Move();
                if (Input.GetKey("joystick " + id + " button 11"))
                {
                    if(select()) ready = true;
                }
            }
            else
            {
                if (Input.GetKey("joystick " + id + " button 12"))
                {
                    ready = false;
                }
            }
        }
        if (active && Input.GetKey("joystick " + id + " button 4")){
            GameObject.Find("Main Camera").GetComponent<SceneLoader>().NextScene();
        }

    }

    private void Move()
    {   
        moveHorizontal = Input.GetAxis("P" + id + " Horizontal");

        if(moveHorizontal > 0 && gameObject.transform.position.x < 1441 && time == DELAY_TIME ){
            gameObject.transform.position += new Vector3(400, 0, 0);
            while (time > 0){
                time -= Time.deltaTime * 0.1f;
            }
            time = DELAY_TIME;
        }

        else if (moveHorizontal < 0 && gameObject.transform.position.x > 361 && time == DELAY_TIME)
        {
            gameObject.transform.position -= new Vector3(400, 0, 0);
            while (time > 0)
            {
                time -= Time.deltaTime * 0.1f;
            }
            time = DELAY_TIME;
        }
    }
    private bool select()
    {
        switch (gameObject.transform.position.x){
            case 360 :
                if (!GameObject.Find("Spanky").GetComponent<SelectStatus>().get()){
                    GameObject.Find("Spanky").GetComponent<SelectStatus>().set(true);
                    GameObject.Find("GameControls").GetComponent<DontDestroy>();
                    return true;
                }
                break;
            case 760:
                if (!GameObject.Find("Bumpkin").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Bumpkin").GetComponent<SelectStatus>().set(true);
                    characterName = "Bumpkin";
                    return true;
                }
                break;
            case 1160:
                if (!GameObject.Find("Hottie").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Hottie").GetComponent<SelectStatus>().set(true);
                    characterName = "Hottie";
                    return true;
                }
                break;
            case 1560:
                if (!GameObject.Find("Foxy").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Foxy").GetComponent<SelectStatus>().set(true);
                    characterName = "Foxy";
                    return true;
                }
                break;
        }
        return false;
    }
}
