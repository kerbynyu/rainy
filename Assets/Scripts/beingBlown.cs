using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beingBlown : MonoBehaviour
{
    public bool blown;
    public List<bool> blowDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        blow playerScr = GetComponent<blow>();
        if (playerScr.vapor && blown)
        {
            if (blowDirection[0])
            {
                transform.Translate(new Vector2(0, 0.1f));
            }
            else if (blowDirection[1])
            {
                transform.Translate(new Vector2(0, -0.1f));
            }
            else if (blowDirection[2])
            {
                transform.Translate(new Vector2(-0.1f, 0));
            }
            else if (blowDirection[3])
            {
                transform.Translate(new Vector2(0.1f, 0));
            }
        }
    }

}
