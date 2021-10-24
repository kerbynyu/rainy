using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public int ID;
    public Color colorOfDrop;
    public Component[] childrenDrops;
    public List<GameObject> drops = new List<GameObject>();

    public float tiltAngle = 90.0f;
    public float smooth;

    public Quaternion target;

    public bool isLanded;

    public float loudnessAdjustment;
    public float rotateStartNum;
    public float rotateLimitTimeReset;
    public float rotateLimitTime;

    public float force;
    public float weight;
    public float dropSpeed;
    private Rigidbody2D myRigidbody;

    public bool goingRight = true;
    void Start()
    {
        childrenDrops = GetComponentsInChildren<Transform>();

        foreach (Transform drop in childrenDrops)
        {
            if (drop.gameObject != gameObject)
            drops.Add(drop.gameObject);
        }

        force = Mic.MicLoudness * loudnessAdjustment;
        myRigidbody = GetComponent<Rigidbody2D>();

        rotateLimitTime = rotateLimitTimeReset;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            target = Quaternion.Euler(0, 0, target.eulerAngles.z + 90);        
        }
        rotate(target);

        force = Mic.MicLoudness * 1000;
        if (force > 0.5 && goingRight)
        {
            myRigidbody.velocity = new Vector2(force * weight, dropSpeed);
            //myRigidbody.AddForce(transform.right * force * weight, ForceMode2D.Impulse);
        }
        else if (force > 0.5 && !goingRight)
        {
            myRigidbody.velocity = new Vector2(force * weight * -1, dropSpeed);
        }
        else
        {
            myRigidbody.velocity = new Vector2(0, dropSpeed);
        }

        changeDirection();
        rotateSetTime();
    }

    private void FixedUpdate()
    {
        if (force > rotateStartNum && rotateLimitTime < 0)
        {
            target = Quaternion.Euler(0, 0, target.eulerAngles.z + 90);
            rotateLimitTime = rotateLimitTimeReset;
        }
    }

    public void changeColor()
    {
        foreach (GameObject drop in drops)
        {
            drop.GetComponent<SpriteRenderer>().color = colorOfDrop;
        }
    }

    public void rotate(Quaternion target)
    {
        Debug.Log("rotating");
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    void rotateSetTime()
    {
        if (rotateLimitTime >0)
        {
            rotateLimitTime -= Time.deltaTime;

        }
    }

    void changeDirection()
    {
        if (transform.position.x < 0 && force < 5)
        {
            goingRight = true;
        } else if (transform.position.x > 0 && force < 5)
        {
            goingRight = false;
        }
    }
}
