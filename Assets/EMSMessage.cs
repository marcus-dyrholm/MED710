using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSMessage : MonoBehaviour
{


    public EMSScript EMSScript;

    public Telekinesis telekinesisRight;
    public string command_to_stimulate_this_player = "C0I100T1000G";
    private string message_to_stimulate_this_player;

    float time1;
    float timeOut = 0.050f;

    float time2;

    bool channel1Sent, channel2Sent =false;




    void Start()
    {
        message_to_stimulate_this_player = command_to_stimulate_this_player;
    }

    public void message()
    {

        EMSScript.sendMessage(message_to_stimulate_this_player);

    }

    void FixedUpdate()
    {
        time1 += Time.deltaTime;
        if (telekinesisRight.m_ActiveObject != null)
        {
            int intensity = Mathf.RoundToInt(map(telekinesisRight.force.y, -200f, 800f, 0, 100));
            Mathf.Clamp(intensity, 0, 100);

            if (time1 >= 0.025f && !channel1Sent)
            {
                  EMSScript.sendMessage("C0I" + intensity + "T100G");
                  channel1Sent = true;
            }
            else if (time1 >= timeOut)
            {
                EMSScript.sendMessage("C1I" + intensity + "T100G");
                time1 = 0;
                channel1Sent = false;
                
            }
            
        }


    }



    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }





}
