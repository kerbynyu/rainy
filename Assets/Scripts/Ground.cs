using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<WaterDrop>() != null)
        {
            if (collision.gameObject.GetComponent<Drop>() != null)
            {
                WaterManager.waitTime = WaterManager.waitTimeReset;
                Destroy(collision.gameObject);
                WaterManager.timeToDrop = true;
            } else
            {
                if (collision.gameObject.GetComponentInParent<Drop>() != null)
                {
                    WaterManager.waitTime = WaterManager.waitTimeReset + 1.0f;
                    Destroy(collision.gameObject);
                    WaterManager.timeToDrop = true;
                }
            }
        }
    }
}
