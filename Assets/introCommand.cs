using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introCommand : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool toShow;
    public GameObject next;
    public bool nextScene;
    public float counter;
    public bool six;
    public floatText txt;
    // Start is called before the first frame update
    void Start()
    {
        var c = sr.color;
        c.a = 0;
        sr.color = c;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!six)
        {
            if (toShow)
            {
                var c = sr.color;
                float tempA = c.a;
                tempA += 0.05f;
                c.a = tempA;
                sr.color = c;
            }
            else
            {
                var c = sr.color;
                c.a = 0;
                sr.color = c;
            }
        }

        else
        {
            if (nextScene)
            {
                counter += 1;
                if (counter > 200)
                {
                    var c = sr.color;
                    float tempA = c.a;
                    tempA += 0.05f;
                    c.a = tempA;
                    sr.color = c;
                }
                if (counter > 230)
                {
                    SceneManager.LoadScene("updated", LoadSceneMode.Single);
                }
            }

        }
    }


    public void showUp()
    {
        toShow = true;
        if (next != null)
        {
            next.SetActive(true);
        }
    }

    public void goNext()
    {
        nextScene = true;
    }

    public void riseText()
    {
        txt.rise = true;
    }
}
