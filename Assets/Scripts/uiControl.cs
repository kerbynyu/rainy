using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class uiControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public bool mouse_over = false;
    public Image tutorial;

    private void Start()
    {
        tutorial.enabled = false;
    }
    void Update()
    {
        if (mouse_over)
        {
            tutorial.enabled = true;
        }
        else
        {
            tutorial.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }
}
