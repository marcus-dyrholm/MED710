using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VelocityTesting : MonoBehaviour
{

    public Telekinesis telekinesis;
    public Player player;
    private Transform handPos;
    private GameObject hand;
    public Vector3 localVelocity;
    public float distance;

    private void Start()
    {
       

    }

    private void Update()
    {
        distance = telekinesis.m_fDistance;
        //Debug.Log(distance);

        localVelocity = transform.InverseTransformDirection(this.GetComponent<HandPhysics>().handCollider.GetComponent<Rigidbody>().velocity);

        if (telekinesis.m_ActiveObject!= null && localVelocity.z >1)
        {
            //telekinesis.m_ActiveObject.GetComponent<Rigidbody>().AddForce(Vector3.forward);
            telekinesis.m_fDistance += 1;
            Debug.Log("throwing");
        }

        if (telekinesis.m_ActiveObject != null && telekinesis.m_fDistance >= 0)
        {
            telekinesis.m_fDistance += map(localVelocity.z, -0.1f, 0.1f, -0.01f, 0.01f );
        }

        if (telekinesis.m_ActiveObject != null && telekinesis.m_fDistance < 0)
        {
            telekinesis.m_fDistance -= map(localVelocity.z, -0.1f, 0.1f, -0.01f, 0.01f );
        }

        //telekinesis.m_fDistance = map(localVelocity.z, -10, 10, -0.1f, 0.1f);
    }
    
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
