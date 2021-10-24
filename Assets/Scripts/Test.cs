using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] Text textToShow;
    //[SerializeField] Drop drop;
    private void Update()
    {
        //textToShow.text = drop.rotateLimitTime + "";
        if (FindObjectOfType<Drop>() != null)
        textToShow.text = FindObjectOfType<Drop>().force + "";
        //Debug.Log(Mic.MicLoudness);
    }
}
