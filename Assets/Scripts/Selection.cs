using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public GameObject Foxy, Spanky, Bumpkin, Hottie;
    public const float DELAY_TIME = 25000f;
    public int id ;

    private float moveHorizontal;
    private bool ready = false;
    private bool active = false;
    private bool selected = false;
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
                    Select();
                    ready = true;
                }
            }
            else
            {
                if (Input.GetKey("joystick " + id + " button 12"))
                {
                    ready = false;
                    Deselect();
                }
            }
            ShowModel();
        }
        if (active && selected && Input.GetKey("joystick " + id + " button 4")){
            GameObject.Find("Main Camera").GetComponent<SceneLoader>().NextScene();
        }


    }

    private void Move()
    {
        GameObject[] playerSelects = GameObject.FindGameObjectsWithTag("PlayerSelect");
        moveHorizontal = Input.GetAxis("P" + id + " Horizontal");

        if(moveHorizontal > 0 && gameObject.transform.position.x < 1441 && time == DELAY_TIME ){
            gameObject.transform.position += new Vector3(432, 0, 0);


            while (time > 0){
                time -= Time.deltaTime * 0.1f;
            }
            time = DELAY_TIME;
        }

        else if (moveHorizontal < 0 && gameObject.transform.position.x > 361 && time == DELAY_TIME)
        {
            gameObject.transform.position -= new Vector3(432, 0, 0);

            while (time > 0)
            {
                time -= Time.deltaTime * 0.1f;
            }
            time = DELAY_TIME;
        }
       
    }

    private void ShowModel (){
        float pos = this.gameObject.transform.position.x;
        switch (pos){
            case 340:
                Spanky.SetActive(true);
                break;
            case 772:
                Hottie.SetActive(true);
                break;
            case 1204:
                Bumpkin.SetActive(true);
                break;
            case 1636:
                Foxy.SetActive(true);
                break;
            default:
                Spanky.SetActive(false);
                Hottie.SetActive(false);
                Bumpkin.SetActive(false);
                Foxy.SetActive(false);
                break;
        }
    }
    private void Deselect(){
        switch (gameObject.transform.position.x)
        {
            case 340:
                if (!GameObject.Find("Spanky").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Spanky").GetComponent<SelectStatus>().set(false);
                    GameObject.Find("GameControls").GetComponent<DontDestroy>().idList.Remove("Spanky");
                    GameObject.Find("SpankyName").GetComponent<Image>().enabled = false;
                    selected = false;
                }
                break;
            case 772:
                if (!GameObject.Find("Hottie").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Hottie").GetComponent<SelectStatus>().set(false);
                    GameObject.Find("GameControls").GetComponent<DontDestroy>().idList.Remove("Hottie");
                    GameObject.Find("HottieName").GetComponent<Image>().enabled = false;
                    selected = false;
                }
                break;
            case 1204:
                if (!GameObject.Find("Bumpkin").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Bumpkin").GetComponent<SelectStatus>().set(false);
                    GameObject.Find("GameControls").GetComponent<DontDestroy>().idList.Remove("Bumpkin");
                    GameObject.Find("BumpkinName").GetComponent<Image>().enabled = false;
                    selected = false;
                }
                break;
            case 1636:
                if (!GameObject.Find("Foxy").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Foxy").GetComponent<SelectStatus>().set(false);
                    GameObject.Find("GameControls").GetComponent<DontDestroy>().idList.Remove("Foxy");
                    GameObject.Find("FoxyName").GetComponent<Image>().enabled = false;
                    selected = false;
                }
                break;
        }
    }
    private void Select()
    {
        switch (gameObject.transform.position.x){
            case 340:
                if (!GameObject.Find("Spanky").GetComponent<SelectStatus>().get()){
                    GameObject.Find("Spanky").GetComponent<SelectStatus>().set(true);
                    GameObject.Find("GameControls").GetComponent<DontDestroy>().idList.Add("Spanky",id);
                    GameObject.Find("SpankyName").GetComponent<Image>().enabled = true;
                    selected = true;
                }
                break;
            case 772:
                if (!GameObject.Find("Hottie").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Hottie").GetComponent<SelectStatus>().set(true); 
                    GameObject.Find("GameControls").GetComponent<DontDestroy>().idList.Add("Hottie", id);
                    GameObject.Find("HottieName").GetComponent<Image>().enabled = true;
                    selected = true;
                }
                break;
            case 1204:
                if (!GameObject.Find("Bumpkin").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Bumpkin").GetComponent<SelectStatus>().set(true);
                    GameObject.Find("GameControls").GetComponent<DontDestroy>().idList.Add("Bumpkin", id);
                    GameObject.Find("BumpkinName").GetComponent<Image>().enabled = true;
                    selected = true;
                }
                break;
            case 1636:
                if (!GameObject.Find("Foxy").GetComponent<SelectStatus>().get())
                {
                    GameObject.Find("Foxy").GetComponent<SelectStatus>().set(true);
                    GameObject.Find("GameControls").GetComponent<DontDestroy>().idList.Add("Foxy", id);
                    GameObject.Find("FoxyName").GetComponent<Image>().enabled = true;
                    selected = true;
                }
                break;
        }
    }
}
