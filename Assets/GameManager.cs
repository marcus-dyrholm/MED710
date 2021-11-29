using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ambulance ambulance;
    public List<GameObject> ambulanceWaypoints;
    public GameObject[] snapToContainers;
    public GameObject[] snapToConcreate;
    public GameObject[] fire;

    private bool allFireInactive = true;

    // Update is called once per frame

    private void Start()
    {
        ambulanceWaypoints = ambulance.waypoints;
        fire = GameObject.FindGameObjectsWithTag("Fire");
    }

    void Update()
    {
        if (ambulance.current == 4)
        {
            ambulance.speed = 0;
            if (snapToContainers[0].activeInHierarchy && snapToContainers[1].activeInHierarchy && snapToContainers[2].activeInHierarchy)
            {
           
                ambulance.speed = 5;
            }
        }

        if (ambulance.current == 5)
        {
            ambulance.speed = 0;
            if (snapToConcreate[0].activeInHierarchy && snapToConcreate[1].activeInHierarchy)
            {
                ambulance.speed = 5;
            }
        }

        if (ambulance.current == 9)
        {
            ambulance.speed = 0;
            for (int i = 0; i < fire.Length; i++)
            {
                if (fire[i].activeInHierarchy)
                {
                    allFireInactive = false;
                    break;
                }
                else
                {
                    allFireInactive = true;
                }



            }
            if (allFireInactive)
            {
                ambulance.speed = 5;
            }
        }

        if (ambulance.current == 10)
        {
            ambulance.speed = 0;
            //activate questionnaire
        }

    }
}
