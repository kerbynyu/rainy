using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    GameObject[] sampleCube = new GameObject[512];
    public float maxScale;
    [SerializeField]AudioSpectrum ass;

    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject instanceSampleCube = (GameObject)Instantiate(sampleCubePrefab);
            instanceSampleCube.transform.position = this.transform.position;
            //instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "cube" + i;
            instanceSampleCube.transform.position = new Vector2(instanceSampleCube.transform.position.x, (instanceSampleCube.transform.position.y - 1 * i * 0.02f));
            sampleCube[i] = instanceSampleCube;
        }
    }

    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (sampleCube != null)
            {
                sampleCube[i].transform.localScale = new Vector2((ass.samples[i] * maxScale), 1);
            }
        }        
    }
}
