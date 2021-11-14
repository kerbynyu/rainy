using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteFade : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var c = sr.color;
        float a = c.a;
        a -= 0.05f;
        c.a = a;
        sr.color = c;
    }

}
