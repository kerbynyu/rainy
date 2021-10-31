using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaporWaterPass : MonoBehaviour
{
    public blow player;
    public BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.vapor || player.water)
        {
            box.enabled = false;
        }
        else
        {
            box.enabled = true;
        }
    }
}
