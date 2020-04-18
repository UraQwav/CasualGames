using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleBit : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(other.gameObject);

        }
    }
}
