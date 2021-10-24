using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioSpectrum : MonoBehaviour
{
    AudioSource audioSource;
    public float[] samples = new float[512];
    public static float[] freqBand = new float[8];

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        getSpectrumAudioSource();
    }

    void getSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void makeFrequencyBands()
    {
        /*
         * 196 -> 329.63 Hertz G3 to E4
         * 
         * 329.63 - 196 = 133.63
         * 
         * 0 = 4.5 ~ 196
         * 1 = 4.9
         * 2 = 5.3
         * 3 = 5.7
         * 4 = 6.1
         * 5 = 6.5
         * 6 = 6.9
         * 7 = 7.3
         * 
         */

        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            for (float j = 4.5f; j <= 7.3f; j+=0.4f)
            {

            }
        }
    }
}
