using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public fanBlowing fan;
    public bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        fan = transform.parent.gameObject.GetComponent<fanBlowing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            fan.activated = true;
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
