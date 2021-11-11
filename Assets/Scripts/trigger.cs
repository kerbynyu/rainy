using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public gate theGate;
    public bool triggered;
    public float counter;
    public ParticleSystem particles;
    public Animator m_Animator;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;

        //theGate = transform.parent.gameObject.GetComponent<gate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {m_Animator.GetComponent<Animator>().enabled = false;
            theGate.activated = true;

            m_Animator.GetComponent<Animator>().enabled = true;
            particles.Stop();
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
        if (collision.gameObject.GetComponent<blow>()!=null && collision.gameObject.GetComponent<blow>().ice)
        {
            triggered = true;
        }
    }

}
