using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBeatMove : MonoBehaviour
{
    // Start is called before the first frame update
    //Цель (пункт Б)
    private GameObject[] target;
     
    //Стартовая позиция (ось Z)
    private float _startPos;
    //Конечная позиция (ось Z)
    private float _endPos;
    private float _endPos2;
    // Use this for initialization
    void Start ()
    {
        //target = GameObject.FindGameObjectsWithTag("CircleOfPointBeat");
        ////Запоминаем начальную и конечную позиции
        //_startPos = transform.position.x;
        //_endPos = target[0].transform.position.x;
        //_endPos2 = target[1].transform.position.x;
    }
     
    // Update is called once per frame
    void Update ()
    {
        ////Новая позиция по оси Z
        //float _x = Mathf.SmoothStep(_startPos, _endPos, Time.time/4);

        ////Устанавливаем новую позицию
        //transform.position = new Vector3(_x, transform.position.y,-5f);
        //if(_endPos == transform.localPosition.x)
        //{

        //    float _x2 = Mathf.SmoothStep(_endPos, _endPos2, Time.time);
        //    Debug.Log("eeee");
        //    //Устанавливаем новую позицию
        //    transform.position = new Vector3(_x2, transform.position.y, -5f);
        //}
        transform.position += new Vector3(-0.12f, 0f, 0f);
        Destroy(gameObject,5f);
    }
}
