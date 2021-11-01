using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    public bool activated;
    public float distance;
    public float counter;
    public bool horizontal;
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
            if (counter < distance)
            {
                counter += 1;

                if (horizontal)
                {
                    transform.Translate(new Vector2(-0.2f, 0));
                }
                else
                {
                    transform.Translate(new Vector2(0, 0.1f));
                }
            }
        }
    }

}
