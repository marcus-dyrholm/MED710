using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VelocityTesting : MonoBehaviour
{

    public Telekinesis telekinesis;
    public Player player;
    private Transform handPos;
    private GameObject hand;
    public Vector3 localVelocity;
    public float distance;
    public float velocityRange;
    public float velocityNewRange;

    private GameObject _player;
    
    public SteamVR_Action_Boolean setdistance; //Grab Pinch is the trigger, select from inspecter
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        distance = telekinesis.m_fDistance;
        //Debug.Log(distance);

        localVelocity = transform.InverseTransformDirection(this.GetComponent<HandPhysics>().handCollider.GetComponent<Rigidbody>().velocity);
/*
        if (telekinesis.m_ActiveObject!= null && localVelocity.z >1)
        {
            //telekinesis.m_ActiveObject.GetComponent<Rigidbody>().AddForce(Vector3.forward);
            telekinesis.m_fDistance += 1;
            Debug.Log("throwing");
        }
*/
        if (telekinesis.m_ActiveObject != null && telekinesis.m_fDistance >= 0)
        {
            telekinesis.m_fDistance += map(localVelocity.z, -velocityRange, velocityRange, -velocityNewRange, velocityNewRange );
        }

        if (telekinesis.m_ActiveObject != null && telekinesis.m_fDistance < 0)
        {
            telekinesis.m_fDistance -= map(localVelocity.z, -velocityRange, velocityRange, -velocityNewRange, velocityNewRange );
        }

        SteamVR_Input.actionsBoolean[1].GetStateDown(inputSource);

        //telekinesis.m_fDistance = map(localVelocity.z, -10, 10, -0.1f, 0.1f);
    }

    private void distanceSet()
    {
        distance = Vector3.Distance(this.transform.position, _player.transform.position);
    }
    
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
    
    
}
