using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatText : MonoBehaviour
{
    public bool rise;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, -13);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rise)
        {
            transform.Translate(new Vector2(0, 0.05f));
        }
    }
}
