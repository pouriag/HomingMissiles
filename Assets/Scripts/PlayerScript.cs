using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed;
    public float power;
    public int reverse = 1;
    public int id = 1;

    private float moveHorizontal;
    private float moveVertical;
    private float origPower;
    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        origPower = power;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Move();
	}

    private void Move()
    {

        moveHorizontal = Input.GetAxis("P"+id+" Horizontal");
        moveVertical = Input.GetAxis("P" + id + " Vertical");

        rigidBody.AddForce(new Vector2(moveHorizontal * speed, moveVertical * speed * reverse));
       

        //float deltaX = moveHorizontal * Time.deltaTime * speed;
        //float newX = transform.position.x + deltaX;
        //float deltaY = moveVertical * Time.deltaTime * speed;
        //float newY = transform.position.y + deltaY;

        //transform.position = new Vector2(newX, newY);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Collider2D other = collision.collider;

    //    if (other.tag == "Player")
    //    {
    //        other.GetComponent<PlayerScript>().power = 0;

    //        Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();

    //        if (otherRB != null)
    //        {
    //            print(otherRB);
    //            otherRB.AddForce(rigidBody.velocity * power);
    //        }
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Collider2D other = collision.collider;

    //    if (other.tag == "Player")
    //    {
    //        other.GetComponent<PlayerScript>().power = origPower;
    //    }
    //}
}
