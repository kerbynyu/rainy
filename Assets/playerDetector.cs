using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class playerDetector : MonoBehaviour
{
    public bool detected;
    public bool switchCamera;
    public CinemachineVirtualCamera oldVC;
    public CinemachineVirtualCamera newVC;
    public CinemachineVirtualCamera bigVC;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detected = true;
            if (switchCamera)
            {
                bigVC.enabled = false;
                oldVC.enabled = false;
                newVC.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.tag == "Player")
        {
            detected = false;
            if (switchCamera)
            {
                newVC.enabled = false;
                oldVC.enabled = false;
                bigVC.enabled = true;
            }
        }
        */
    }

}