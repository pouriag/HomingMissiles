using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public float speed;
    public float itemTime = 5f;
    public int points = 0;
    public string characterName = "";

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

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}

    private void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.E))
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

        if (Input.GetKeyDown(KeyCode.Space) && firstHome)
        {
            mainCam.GetComponent<D2FogsPE>().enabled = true;
        }
    }

    void FixedUpdate ()
    {
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
                SavePoints(this.gameObject);
                Destroy(this.gameObject);
            }
        }
        if (other.tag.StartsWith("Target"))
        {
            char c = other.tag[other.tag.Length - 1];
            char i = id.ToString()[0];

            if (other.tag[other.tag.Length - 1] == id.ToString()[0])
            {

                points = (int)(Time.timeSinceLevelLoad * 1.2);
                if (SavePoints(this.gameObject) == 1) firstHome = true;
                Destroy(child);
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
                    SavePoints(this.gameObject);
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
        Debug.Log(points);
        GameObject.Find("Panel").GetComponent<ShowPoints>().points.Add(id, points);
        return GameObject.Find("Panel").GetComponent<ShowPoints>().points.Count;
    }

    public void setId(int id){

        this.id = id;

    }
}
