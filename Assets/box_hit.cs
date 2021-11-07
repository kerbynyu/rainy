using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_hit : MonoBehaviour
{
    public bool shouldMove = true;
    // Start is called before the first frame update
    void Start()
    {
        shouldMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "waterPass") 
        {
            shouldMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "waterPass")
        {
            shouldMove = true;
        }
    }
    
}
