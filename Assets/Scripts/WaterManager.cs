using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public List<GameObject> waterDrops = new List<GameObject>();

    public int currentDropID = 0;

    public static bool timeToDrop = true;

    public static float waitTime;
    public static float waitTimeReset;

    public List<GameObject> dropPOS = new List<GameObject>();
    public GameObject currentDrop;
    public GameObject dropPrefab;
    void Start()
    {
        waitTimeReset = 10.0f;
        waitTime = waitTimeReset;

        
    }

    
    void Update()
    {
        nextDrop();

        switch(FindObjectOfType<Plant>().water)
        {
            case 0:
            case 1:
            case 2:
                if (currentDrop == null) currentDrop = Instantiate(dropPrefab, dropPOS[0].transform.position, dropPOS[0].transform.rotation);
                currentDrop.SetActive(true);
                break;
            case 3:
            case 4:
                if (currentDrop == null) currentDrop = Instantiate(dropPrefab, dropPOS[1].transform.position, dropPOS[0].transform.rotation);
                currentDrop.SetActive(true);

                break;
            case 5:
            case 6:
                if (currentDrop == null) currentDrop = Instantiate(dropPrefab, dropPOS[2].transform.position, dropPOS[2].transform.rotation);
                currentDrop.SetActive(true);

                break;
            case 7:
            case 8:
                if (currentDrop == null) currentDrop = Instantiate(dropPrefab, dropPOS[3].transform.position, dropPOS[0].transform.rotation);
                currentDrop.SetActive(true);

                break;
            case 9:
            case 10:
                if (currentDrop == null) currentDrop = Instantiate(dropPrefab, dropPOS[4].transform.position, dropPOS[0].transform.rotation);
                currentDrop.SetActive(true);

                break;
            case 11:
            case 12:
                if (currentDrop == null) currentDrop = Instantiate(dropPrefab, dropPOS[5].transform.position, dropPOS[0].transform.rotation);
                currentDrop.SetActive(true);

                break;
        }
    }

    public void nextDrop()
    {
        if (waitTime >0 && timeToDrop)
        {
            waitTime -= Time.deltaTime;
        } else
        {
            if (currentDropID < waterDrops.Count)
            {
                waterDrops[currentDropID].SetActive(true);
                currentDropID++;
                waitTime = waitTimeReset;
                timeToDrop = false;
            }
        }
    }
}
