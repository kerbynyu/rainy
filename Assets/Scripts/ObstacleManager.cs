using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void setObstacle(int index)
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (i != index)
            {
                obstacles[i].SetActive(false);
            } else
            {
                obstacles[i].SetActive(true);
            }
        }
    }
}
