using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medusa : MonoBehaviour
{
    public GameObject player;
    public Transform beamPos;
    public bool invaded;
    public GameObject bullet;
    // Start is called before the first frame update

    public Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("water");
        if (player.transform.position.y > beamPos.position.y && invaded)
        {
            GameObject projectile = Instantiate(bullet, beamPos.position, Quaternion.Euler(0, 0, 0));
            invaded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            invaded = true;
        }
    }
}
