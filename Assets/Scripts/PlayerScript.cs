using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UB;

public enum Items
{
    Control,
    Speed,
    Shield,
    None
}

public class PlayerScript : MonoBehaviour {

    public GameObject child;
    public GameObject mainCam;
    public GameObject explode;
    public GameObject landCeleb;

    public Image card;
    public Text score;
    public Sprite deadPic;

    public float speed;
    public float itemTime = 5f;
    public int points = 0;
    public string characterName = "";

    private bool landed = false;
    private int id;

    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody rigidBody;
    private Items activeItem;
    private bool itemActive = false;
    private float activeItemStartTime = 0;

    private bool shield = false;
    private bool control = false;
    private bool xspeed = false;
    private bool firstHome = false;
    private bool hasChild = false;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        if (!gameObject.transform.GetChild(0).gameObject.activeSelf) gameObject.GetComponent<BoxCollider>().enabled = false;

        if (!hasChild)
        {
            if (gameObject.transform.GetChild(0).gameObject.activeSelf)
            {
                hasChild = true;
            }
            else
            {
                card.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if(hasChild){
            if(!landed) points = (int)(Time.timeSinceLevelLoad * 1.2);
            score.text = points.ToString();

            if (itemActive)
            {
                if (Time.timeSinceLevelLoad - activeItemStartTime > itemTime)
                {
                    control = false;
                    shield = false;
                    if (xspeed)
                    {
                        xspeed = false;
                        GameObject.FindObjectOfType<BackgroundScript>().scrollSpeed -= 3f;
                    }
                    activeItem = 0;
                    activeItem = Items.None;
                    itemActive = false;
                }
            }

            if (Input.GetKeyDown("joystick "+ id+ " button 11") )
            {
                if (activeItem == Items.Control)
                {
                    control = true;
                    itemActive = true;
                    activeItemStartTime = Time.timeSinceLevelLoad;
                }
                else if (activeItem == Items.Shield)
                {
                    shield = true;
                    itemActive = true;
                    activeItemStartTime = Time.timeSinceLevelLoad;
                }
                else if (activeItem == Items.Speed)
                {
                    GameObject.FindObjectOfType<BackgroundScript>().scrollSpeed += 3f;
                    xspeed = true;
                    itemActive = true;
                    activeItemStartTime = Time.timeSinceLevelLoad;
                }
            }

            if (Input.GetKeyDown("joystick " + id + " button 11") && firstHome)
            {
                mainCam.GetComponent<D2FogsPE>().enabled = true;
                StartCoroutine(WaitForFog());
            }
        }
    }

    void FixedUpdate ()
    {
        if (hasChild)
            Move();
	}

    private void Move()
    {

        moveHorizontal = Input.GetAxis("P"+id+" Horizontal");
        moveVertical = Input.GetAxis("P" + id + " Vertical");

        //moveHorizontal = Input.GetAxis("Horizontal");
        //moveVertical = Input.GetAxis("Vertical");

        if (control)
        {
            rigidBody.velocity = new Vector3(moveHorizontal * speed, moveVertical * speed, 0f);
        }
        else
        {
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
            rigidBody.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            if (shield)
            {
                shield = false;
                transform.position = new Vector3(other.transform.position.x + 1.5f, transform.position.y, transform.position.z);
            }
            else
            {
                card.sprite = deadPic;
                points = 0;
                score.text = points.ToString();
                SavePoints(this.gameObject);
                Destroy(other.gameObject);
                Instantiate(explode, transform.position, Quaternion.identity);
                mainCam.GetComponent<CameraShake>().shakeDuration = 0.5f;
                Destroy(this.gameObject);
            }
        }
        if (other.tag.StartsWith("Target"))
        {
            char c = other.tag[other.tag.Length - 1];
            char i = id.ToString()[0];

            if (other.tag.Substring(6) == characterName)
            {
                landed = true;
                Instantiate(landCeleb, transform.position, Quaternion.identity);
                if (SavePoints(this.gameObject) == 1) firstHome = true;
                Destroy(child);
                GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                if (shield)
                {
                    shield = false;
                    transform.position = new Vector3(other.transform.position.x + 1.5f, transform.position.y, transform.position.z);
                }
                else
                {
                    card.sprite = deadPic;
                    points = 0;
                    score.text = points.ToString();
                    SavePoints(this.gameObject);
                    Destroy(other.gameObject);
                    Instantiate(explode, transform.position, Quaternion.identity);
                    mainCam.GetComponent<CameraShake>().shakeDuration = 0.5f;
                    Destroy(this.gameObject);
                }
            }
        }

        if (other.tag == "Control")
        {
            Destroy(other.gameObject);
            activeItem = Items.Control;
        }
        else if (other.tag == "Shield")
        {
            Destroy(other.gameObject);
            activeItem = Items.Shield;
        }
        else if (other.tag == "Speed")
        {
            Destroy(other.gameObject);
            activeItem = Items.Speed;
        }
    }

    private int SavePoints(GameObject gameObject)
    {
        GameObject.Find("Panel").GetComponent<ShowPoints>().points.Add(id, points);
        return GameObject.Find("Panel").GetComponent<ShowPoints>().points.Count;
    }

    public void setId(int id){

        this.id = id;

    }

    private IEnumerator WaitForFog()
    {
        if (firstHome)
        {
            firstHome = false;
            yield return new WaitForSeconds(5f);
            mainCam.GetComponent<D2FogsPE>().enabled = false;
        }
        else
        {
            yield return new WaitForSeconds(10f);
            firstHome = true;
        }
    }
}
