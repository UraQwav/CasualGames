using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapBeatMacker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject audioContainer;
    public static bool startRecordingSempl = false;
    private bool finishRecordingSempl = false;
    private int semplDuraction = 5;
    private float timeBetweenBits = 0f;
    private float timeTwoBetweenBits = 0f;
    private float avgTimeBetweenBits = 0f;
    private int numberOfBits = 1;
    AudioSource[] sources;
    void Start()
    {
        sources = audioContainer.GetComponents<AudioSource>() as AudioSource[];
    }
    public void Record()
    {
        startRecordingSempl = true;
    }
    
    public bool REcord2()
    {
        return startRecordingSempl;
    }
    // Update is called once per frame
    void Update()
    {

        if (startRecordingSempl)
        {
            if (numberOfBits <= semplDuraction)
            {
                timeBetweenBits += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    avgTimeBetweenBits += timeBetweenBits;
                    timeBetweenBits = 0f;
                    numberOfBits++;
                    sources[0].Play();

                }
            }
            else 
            {
                finishRecordingSempl = true;
                startRecordingSempl = false;
            }
        }
        else if(finishRecordingSempl)
        {
            if (numberOfBits!=0)
            {
                avgTimeBetweenBits = avgTimeBetweenBits / numberOfBits;
                numberOfBits = 0;
            }
            Debug.Log("avgTimeBetweenBits " + avgTimeBetweenBits);
            if (timeTwoBetweenBits>avgTimeBetweenBits) 
            {
                sources[0].Play();
                timeTwoBetweenBits = 0f;
            }
            else
            {
                timeTwoBetweenBits += Time.deltaTime;
            }
        }
        //Debug.Log("timeBetweenBits " + timeBetweenBits);
    }
}
