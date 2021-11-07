using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardsPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject fluid;
    public blow playerScr;
    public bool hit;
    public ParticleSystem particles;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.Find("water");
        playerScr = player.GetComponent<blow>();
        fluid = player.GetComponent<blow>().fluid;
        if (playerScr.vapor || playerScr.ice)
        {
            if (!hit)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.5f);
            }
        }else if (playerScr.water)
        {
            if (!hit)
            {
                transform.position = Vector2.MoveTowards(transform.position, fluid.transform.position, 0.5f);
            }
        }
        if (hit)
        {
            particles.Stop();
            counter += 1;
        }
        if (counter > 50)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScr.vapor = false;
            playerScr.water = false;
            playerScr.ice = true;
            hit = true;
        }
    }
}
