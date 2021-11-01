using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotate : MonoBehaviour
{
    public bool activated;
    public Transform gate;
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
        if (activated)
        {
            transform.Rotate(new Vector3(0, 0, 2));
            gate.Translate(new Vector3(0, 0.1f, 0));
        }
    }
}
