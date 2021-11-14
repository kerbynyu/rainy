using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStarts : MonoBehaviour
{
    public List<GameObject> operations;
    public List<GameObject> colliders;
    public bool gameStart;
    public bool doOnce;
    public GameObject bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm.SetActive(false);
        foreach (GameObject op in operations)
        {
            op.SetActive(false);
        }
        foreach (GameObject co in colliders)
        {
            co.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!doOnce)
        {
            if (gameStart)
            {
                bgm.SetActive(true);
                foreach (GameObject op in operations)
                {
                    op.SetActive(true);
                }
                foreach (GameObject co in colliders)
                {
                    co.SetActive(true);
                }
                doOnce = true; ;
            }
        }  
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameStart = true;
        }
    }
}
