using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSMessage : MonoBehaviour
{


    public EMSScript openEMSstim;
    public string command_to_stimulate_this_player = "C0I100T1000G";
    private string message_to_stimulate_this_player;

    void Start()
    {
        message_to_stimulate_this_player = command_to_stimulate_this_player;
    }

    public void message() 
    { 
        
        openEMSstim.sendMessage (message_to_stimulate_this_player); 
    }




    
}
