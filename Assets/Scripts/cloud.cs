using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    public blow player;
    public float counter;
    public bool startCount;
    public GameObject particle;
    public wheelRotate wheel;
    public GameObject fluid;
    public bool rightCloud;
    public bool toWater;
    public float waterCounter;
    public Sprite icedMedusa;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("water").GetComponent<blow>();
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (toWater)
        {
            waterCounter += 1;
            if (waterCounter == 1)
            {
                GameObject f = Instantiate(fluid, player.transform.position, Quaternion.Euler(0, 0, 0));
                player.GetComponent<blow>().fluid = f;
            }
            if (waterCounter > 10)
            {
                toWater = false;
                waterCounter = 0;
            }
        }

        if (counter < 500 && startCount)
        {
            if (!rightCloud)
            {
                counter += 1;
                
                if (counter > 20)
                {
                    particle.SetActive(true);
                }
                if (counter > 80)
                {
                    wheel.activated = true;
                }
            }
            else
            {
                counter += 1;
                GameObject dusa = GameObject.Find("medusa");
                medusa dusaScr = dusa.GetComponent<medusa>();
                
                
                
                
                if (counter > 20)
                {
                    particle.SetActive(true);
                    dusaScr.enabled = false;
                }
                if (counter > 100)
                {

                    dusa.GetComponent<SpriteRenderer>().sprite = icedMedusa;
                    ParticleSystem dusaPar = dusa.transform.GetChild(0).GetComponent<ParticleSystem>();
                    dusaPar.Stop();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.water = true;
            player.vapor = false;
            player.ice = false;
            startCount = true;
            toWater = true;
        }
    }


}
