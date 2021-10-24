using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanBlowing : MonoBehaviour
{
    public List<bool> blowDirection;
    public bool activated = true;
    public GameObject wind;
    public BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {

            wind.SetActive(true);
            box.enabled = true;
        }
        else
        {
            wind.SetActive(false);
            box.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && activated)
        {
            GameObject player = collision.gameObject;
            beingBlown playerScr = player.GetComponent<beingBlown>();
            playerScr.blown = true;
            for (int i = 0; i < blowDirection.Count; i++)
            {
                playerScr.blowDirection[i] = blowDirection[i];
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            beingBlown playerScr = player.GetComponent<beingBlown>();
            playerScr.blown = false;
            for (int i = 0; i < blowDirection.Count; i++)
            {
                playerScr.blowDirection[i] = false;
            }
        }
    }

}
