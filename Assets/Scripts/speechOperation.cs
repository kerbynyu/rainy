using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speechOperation : MonoBehaviour
{
    public blow player;
    public GameObject fluid;
    public Transform summonPos;
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
        if (player.summoned)
        {
            player.vapor = true;
            player.ice = false;
            player.water = false;
            player.moveRight = false;
            player.moveLeft = false;
            if (player.fluid != null)
            {
                player.gameObject.transform.position = player.fluid.transform.position;
                Destroy(player.fluid);
            }
        }
        
    }

    public void waterOperation()
    {
        if (player.summoned)
        {
            player.water = true;
            player.ice = false;
            player.vapor = false;
            player.moveRight = false;
            player.moveLeft = false;
            if (player.fluid == null)
            {
                GameObject thisFluid = Instantiate(fluid, player.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                player.fluid = thisFluid;
            }
        }
    }

    public void iceOperation()
    {
        if (player.summoned)
        {
            player.ice = true;
            player.water = false;
            player.vapor = false;
            player.moveRight = false;
            player.moveLeft = false;
            if (player.fluid != null)
            {
                player.gameObject.transform.position = player.fluid.transform.position;
                Destroy(player.fluid);
            }
        }
        
    }

    public void leftOperation()
    {
        if (player.summoned)
        {
            player.moveLeft = true;
            player.moveRight = false;
            if (player.fluid != null)
            {
                player.fluid.GetComponent<water_fluid>().moveLeft = true;
                player.fluid.GetComponent<water_fluid>().moveRight = false;
            }
        }
    }

    public void rightOperation()
    {
        if (player.summoned)
        {
            player.moveLeft = false;
            player.moveRight = true;
            if (player.fluid != null)
            {
                player.fluid.GetComponent<water_fluid>().moveRight = true;
                player.fluid.GetComponent<water_fluid>().moveLeft = false;
            }
        }
    }

    public void stopOperation()
    {
        if (player.summoned)
        {
            player.moveLeft = false;
            player.moveRight = false;
        }
    }

    public void downOperation()
    {
        if (player.water && player.summoned)
        {
            player.moveLeft = false;
            player.moveRight = false;
            if (player.fluid != null)
            {
                player.fluid.GetComponent<water_fluid>().moveDown = true;
                player.fluid.GetComponent<water_fluid>().moveLeft = false;
                player.fluid.GetComponent<water_fluid>().moveRight = false;

            }
        }
    }

    public void summonOperation()
    {
        if (!player.summoned)
        {
            GameObject f = Instantiate(fluid, summonPos.position, Quaternion.Euler(0, 0, 0));
            player.gameObject.SetActive(true);
            player.fluid = f;
            player.water = true;
            player.vapor = false;
            player.ice = false;
            player.summoned = true;
        }
    }

}
