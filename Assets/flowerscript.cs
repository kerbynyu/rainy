using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerscript : MonoBehaviour {

    public Animator m_Animator;

    // Update is called once per frame
    void Update() {
        }

    private void OnTriggerEnter(Collision other) {
        if(other.gameObject.tag == "Player") {
            m_Animator.GetComponent<Animator>().enabled = true;
        } 
    }

    void Start() {
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;
    }

}

