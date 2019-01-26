using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Items
{
    Control,
    Speed,
    Shield,
    None
}

public class PlayerScript : MonoBehaviour {

    public float speed;
    public int id = 1;
    public float itemTime = 10f;

    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody2D rigidBody;
    private Items activeItem;
    private float activeItemTime = 0;
    private float activeItemStartTime = 0;

    private bool shield = false;
    private bool control = false;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        if (activeItem != Items.None)
        {
            activeItemTime += Time.deltaTime;
            if (activeItemTime - activeItemStartTime > itemTime)
            {
                control = false;
                shield = false;
                activeItem = 0;
                activeItem = Items.None;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (activeItem == Items.Control)
            {
                control = true;
                activeItemStartTime = Time.deltaTime;
            }
            else if (activeItem == Items.Shield)
            {
                shield = true;
                activeItemStartTime = Time.deltaTime;
            }
            else if (activeItem == Items.Speed)
            {
                activeItemStartTime = Time.deltaTime;
            }
        }
    }

    void FixedUpdate ()
    {
        Move();
	}

    private void Move()
    {

        //moveHorizontal = Input.GetAxis("P"+id+" Horizontal");
        //moveVertical = Input.GetAxis("P" + id + " Vertical");

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (control)
        {
            rigidBody.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        }
        else
        {
            rigidBody.AddForce(new Vector2(moveHorizontal * speed, moveVertical * speed));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D other = collision.collider;

        if (other.tag == "Obstacle")
        {
            if (shield)
            {
                shield = false;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else if (other.tag.StartsWith("Target"))
        {
            char c = other.tag[other.tag.Length - 1];
            char i = id.ToString()[0];

            if (other.tag[other.tag.Length - 1] == id.ToString()[0])
            {
                print("LAAAAAND!");
            }
            else
            {
                if (shield)
                {
                    shield = false;
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
