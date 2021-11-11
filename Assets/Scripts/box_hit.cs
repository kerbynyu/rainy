using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_hit : MonoBehaviour
{
    public bool shouldMove;
    public LayerMask layers;
    public bool down;
    public bool left;
    public bool right;
    // Start is called before the first frame update
    void Start()
    {
        shouldMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, -0.1f, layers);
        if (down)
        {
            hit = Physics2D.Raycast(transform.position, transform.up, -0.1f, layers);
            Debug.DrawRay(transform.position, transform.up * -0.1f, Color.white);
        }
        else if (left)
        {
            hit = Physics2D.Raycast(transform.position, transform.right, -0.1f, layers);
            Debug.DrawRay(transform.position, transform.right * -0.1f, Color.white);
        }
        else if (right)
        {
            hit = Physics2D.Raycast(transform.position, transform.right, 0.1f, layers);
            Debug.DrawRay(transform.position, transform.right * 0.1f, Color.white);
        }
        if (hit)
        {
            shouldMove = false;
        }
        else
        {
            shouldMove = true;
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "waterPass") 
        {
            shouldMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "waterPass")
        {
            shouldMove = true;
        }
    }
    */

}
