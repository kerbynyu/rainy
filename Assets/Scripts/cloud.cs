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
        if (counter < 500 && startCount)
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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.water = true;
            player.vapor = false;
            player.ice = false;
            startCount = true;
        }
    }


}
