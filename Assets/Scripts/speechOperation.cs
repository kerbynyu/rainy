using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speechOperation : MonoBehaviour
{
    public blow player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void vaporOperation()
    {
        player.vapor = true;
        player.ice = false;
        player.water = false;
        player.moveRight = false;
        player.moveLeft = false;
    }

    public void waterOperation()
    {
        player.water = true;
        player.ice = false;
        player.vapor = false;
        player.moveRight = false;
        player.moveLeft = false;
    }

    public void iceOperation()
    {
        player.ice = true;
        player.water = false;
        player.vapor = false;
        player.moveRight = false;
        player.moveLeft = false;
    }

    public void leftOperation()
    {
        player.moveLeft = true;
        player.moveRight = false;
    }

    public void rightOperation()
    {
        player.moveLeft = false;
        player.moveRight = true;
    }

    public void stopOperation()
    {
        player.moveLeft = false;
        player.moveRight = false;
    }

}
