using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public gate theGate;
    public bool triggered;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        //theGate = transform.parent.gameObject.GetComponent<gate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            theGate.activated = true;
        }
    }

    private void FixedUpdate()
    {
        if (counter < 10 && triggered)
        {
            counter += 1;
            transform.Translate(new Vector2(0, -0.1f));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<blow>().ice)
        {
            triggered = true;
        }
    }

}
