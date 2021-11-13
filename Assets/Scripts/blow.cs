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
    public GameObject vaporObj;
    public GameObject iceObj;
    public bool iced;
    public bool moveLeft;
    public bool moveRight;
    public bool tempControl;
    public BoxCollider2D box;
    public GameObject fluid;
    public ParticleSystem vaporParticles;
    public float vaporCounter;
    public bool summoned;
    public ParticleSystem iceParticles;
    public float iceCounter;

    // Start is called before the first frame update
    void Start()
    {
        vaporParticles.Stop();
        iceParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {

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

        if (vapor || water)
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
            if (fluid != null)
            {
                Destroy(fluid);
            }
            vaporObj.SetActive(true);
            iceObj.SetActive(false);
            rb.velocity = new Vector2(0, force);
            rb.gravityScale = 3;
            transform.Translate(new Vector2(0, 0.1f));
            box.enabled = true;
            iceCounter = 0;
            if (vaporCounter < 15)
            {
                vaporCounter += 1;
                vaporParticles.Play();
            }
            else
            {
                vaporParticles.Stop();
            }
            rb.isKinematic = false;
        }
        else if (water)
        {
            vaporObj.SetActive(false);
            iceObj.SetActive(false);
            rb.gravityScale = 1;
            box.enabled = false;
            if (fluid != null)
            {
                transform.position = fluid.transform.position;
            }
            vaporCounter = 0;
            iceCounter = 0;
            rb.isKinematic = true;
        }
        else if (ice)
        {
            if (fluid != null)
            {
                Destroy(fluid);
            }
            
            vaporObj.SetActive(false);
            rb.gravityScale = 10;
            box.enabled = true;
            vaporCounter = 0;
            rb.isKinematic = false;
            if (iceCounter < 15)
            {
                iceObj.SetActive(false);
                iceCounter += 1;
                iceParticles.Play();
            }
            else
            {
                iceObj.SetActive(true);
                iceParticles.Stop();
            }
        }
    }
}
