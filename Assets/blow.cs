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
    public bool jump;

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
        if (Input.GetKey(KeyCode.E))
        {
            iced = true;
        }
        else
        {
            iced = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && water && landed)
        {
            jump = true;
        }
    }


    private void FixedUpdate()
    {
        //control
        force = Mic.MicLoudness * 10;
        if (jump)
        {
            rb.AddForce(new Vector2(0, 300));
            jump = false;
        }

        if (water)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector2(-0.1f, 0));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector2(0.1f, 0));
            }
        }

        //three states
        if (force > 1 && !iced) {
            water = false;
            ice = false;
            vapor = true;
        }
        else if (!landed && iced)
        {
            vapor = false;
            water = false;
            ice = true;
        }
        else if (landed && !iced && force < 1)
        {
            vapor = false;
            ice = false;
            water = true;
        }

        if (vapor)
        {
            sr.sprite = vaporSpr;
            rb.velocity = new Vector2(0, force);
            rb.gravityScale = 3;
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
