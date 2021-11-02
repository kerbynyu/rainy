using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blow : MonoBehaviour
{
    public float force;
    public Rigidbody2D rb;
    public bool ice;
    public bool water;
    public bool vapor;
    public SpriteRenderer sr;
    public Sprite waterSpr;
    public Sprite vaporSpr;
    public Sprite iceSpr;
    public grounded grd;
    public bool landed;
    public bool iced;
    public bool moveLeft;
    public bool moveRight;
    public bool tempControl;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grd.isGrounded)
        {
            landed = true;
        }
        else
        {
            landed = false;
        }

        //temp control
        if (tempControl)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vapor = true;
                water = false;
                ice = false;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                ice = true;
                water = false;
                vapor = false;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                water = true;
                vapor = false;
                ice = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveRight = true;
                moveLeft = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveLeft = true;
                moveRight = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveLeft = false;
                moveRight = false;
            }
        }
        
    }


    private void FixedUpdate()
    {


        //control

        if (water || vapor)
        {
            if (moveLeft)
            {
                transform.Translate(new Vector2(-0.1f, 0));
            }
            else if (moveRight)
            {
                transform.Translate(new Vector2(0.1f, 0));
            }
        }
        else
        {
            moveLeft = false;
            moveRight = false;
        }

        //three states


        if (vapor)
        {
            sr.sprite = vaporSpr;
            rb.velocity = new Vector2(0, force);
            rb.gravityScale = 3;
            transform.Translate(new Vector2(0, 0.1f));
        }
        else if (water)
        {
            sr.sprite = waterSpr;
            rb.gravityScale = 1;
        }
        else if (ice)
        {
            sr.sprite = iceSpr;
            rb.gravityScale = 10;
        }
    }
}
