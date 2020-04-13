using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    private Rigidbody body;
    public NavMeshAgent agent;
    public GameObject player;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    /*public float GetHorizontal()
    {
        if(gameObject.transform.rotation.y > 180)
        {
            
        }
    }*/

    public void FixedUpdate()
    {
       
        agent.SetDestination(player.transform.position);

    }
}
