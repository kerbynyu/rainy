using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int water =0 ;

    public GameObject plant;
    public SpriteRenderer plantImage;

    public List<Sprite> images;
    public ObstacleManager ob;

    public GameObject thanks;
    void Start()
    {
        plantImage = plant.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        switch(water)
        {
            case 3:
                ob.setObstacle(1);
                break;
            case 5:
                ob.setObstacle(2);
                break;
            case 7:
                ob.setObstacle(3);
                break;
            case 9:
                ob.setObstacle(4);
                break;
            case 11:
                ob.setObstacle(5);
                break;
            case 13:
                ob.setObstacle(1);
                thanks.SetActive(true);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WaterDrop>() != null)
        {
            if (collision.gameObject.GetComponent<Drop>() != null)
            {
                WaterManager.waitTime = WaterManager.waitTimeReset;
                Destroy(collision.gameObject);
                water++;
                plantImage.sprite = images[water];
                WaterManager.timeToDrop = true;
            }
            else
            {
                if (collision.gameObject.GetComponentInParent<Drop>() != null)
                {
                    WaterManager.waitTime = WaterManager.waitTimeReset + 1.0f;
                    Destroy(collision.gameObject);
                    water++;
                    plantImage.sprite = images[water];
                    WaterManager.timeToDrop = true;
                }
            }
            
        }
    }
}
