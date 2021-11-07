using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class water_fluid : MonoBehaviour
{
    private const float spineOffset = 200f;
    public GameObject player;
    public bool moveLeft;
    public bool moveRight;
    public SpriteShapeController shape;
    public List<GameObject> objs;
    public List<Vector2> pos;
    public ParticleSystem particles;
    public float counter;
    public bool moveDown;
    public box_hit leftBox;
    public box_hit rightBox;
    public box_hit downBox;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("water");
        for (int i = 0; i < objs.Count; i++)
        {
            pos[i] = new Vector2(objs[i].transform.localPosition.x, objs[i].transform.localPosition.y);
        }
    }

    private void Awake()
    {
        for (int i = 0; i < shape.spline.GetPointCount(); i++)
        {
            shape.spline.SetTangentMode(i, ShapeTangentMode.Linear);
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            pos[i] = new Vector2(objs[i].transform.localPosition.x, objs[i].transform.localPosition.y);
        }
    }


    private void FixedUpdate()
    {
        if (counter < 15)
        {
            shape.gameObject.SetActive(false);
            counter += 1;
        }
        else
        {
            particles.Stop();
            shape.gameObject.SetActive(true);
        }
        updateVerticies();
        if (moveLeft)
        {
            
            for (int i = 0; i < objs.Count; i++)
            {
                if (leftBox.shouldMove)
                {
                    objs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(-5, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    objs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                }
            }
            if (leftBox.shouldMove)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-5, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            }
            moveRight = false;
            if (!downBox.shouldMove && !leftBox.shouldMove)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                moveLeft = false;
            }
        }
        else if (moveRight)
        {
            for (int i = 0; i < objs.Count; i++)
            {
                if (rightBox.shouldMove)
                {
                    objs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(5, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    objs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                }
            }
            if (rightBox.shouldMove)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(5, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            }
            moveLeft = false;
            if (!downBox.shouldMove && !rightBox.shouldMove)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                moveRight = false;
            }
        }
        else if (moveDown)
        {
            if (downBox.shouldMove)
            {
                for (int i = 0; i < objs.Count; i++)
                {
                    objs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);
                }
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);
            }
            else
            {
                for (int i = 0; i < objs.Count; i++)
                {
                    objs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                }
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                moveDown = false;
                

            }
        }

    }

    public void updateVerticies()
    {
        for (int i = 0; i < shape.spline.GetPointCount(); i++)
        {
            Vector2 vertex = pos[i];
            Vector2 towardsCenter = (Vector2.zero - vertex).normalized;
            float colliderRadius = objs[i].GetComponent<CircleCollider2D>().radius;

            try
            {
                shape.spline.SetPosition(i, vertex-towardsCenter*colliderRadius);
                shape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            }
            catch
            {

            }

            Vector2 lt = shape.spline.GetLeftTangent(i);
            Vector2 newRt = Vector2.Perpendicular(towardsCenter) * lt.magnitude;
            Vector2 newLt = Vector2.zero - newRt;
            shape.spline.SetRightTangent(i, newRt);
            shape.spline.SetLeftTangent(i, newLt);
        }
    }

    
}
