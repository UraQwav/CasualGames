using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointOfBeat;
    public float tapTime = 0f;
    public GameObject Texts;
    // Start is called before the first frame update
    int LoopLength = 4;
    TapBeatMacker tapBeatMacker;
    void Start()
    {
        Texts.GetComponent<Text>().text = "Ostalos Bit For Loop: 5";
        tapBeatMacker = new TapBeatMacker();
    }
    // Update is called once per frame
    void Update()
    {
        if (tapBeatMacker.REcord2())
        {
            tapTime += Time.deltaTime;
            if (tapTime > 3f)
            {
                if (LoopLength > 0)
                {

                    Instantiate(pointOfBeat, transform);
                    tapTime = 0f;
                    LoopLength--;
                    Texts.GetComponent<Text>().text = "Ostalos Bit For Loop: " + LoopLength;
                }
            }
        }
    }
}
