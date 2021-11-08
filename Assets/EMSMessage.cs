using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSMessage : MonoBehaviour
{


    public EMSScript EMSScript;

    public Telekinesis telekinesisRight;
    public string command_to_stimulate_this_player = "C0I100T1000G";
    private string message_to_stimulate_this_player;

    void Start()
    {
        message_to_stimulate_this_player = command_to_stimulate_this_player;
    }

    public void message() 
    { 
        
        EMSScript.sendMessage(message_to_stimulate_this_player); 
        
    }

    void Update()
    {
     if(telekinesisRight.m_ActiveObject != null){   
        int intensity = Mathf.RoundToInt(map(telekinesisRight.force.y, -500f, 500f, 0, 100));
        if(intensity >=0 && intensity <=100){
        EMSScript.sendMessage("C1I"+intensity+"T50G");
        
        //Debug.Log("C1I"+intensity+"T50G");
        }
        //Debug.Log("intensity = " + intensity);
     }
     else{
        EMSScript.sendMessage("C1I0T50G");
     }



    }

        float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }




    
}
