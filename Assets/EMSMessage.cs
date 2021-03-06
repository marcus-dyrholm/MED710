using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSMessage : MonoBehaviour
{
    public EMSScript EMSScript;
    public EMSScript2 EMSScript2;

    public Telekinesis telekinesisRight;
    public string command_to_stimulate_this_player = "C0I100T1000G";
    private string message_to_stimulate_this_player;

    float time1;
    float time2;
    float timeOut = 0.050f;
    
    //Make sure that messages are only sent once per timeout
    bool channel1Sent, channel2Sent = false;
    

    
    
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
    
    void FixedUpdate()
    {
        
        //Timings to ensure that the serial port doesnt get flooded.
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
        if (telekinesisRight.m_ActiveObject != null)
        {
            int intensity = Mathf.RoundToInt(map(telekinesisRight.force.y, -200f, 800f, 0, 100));
            int clampedIntensity = Mathf.Clamp(intensity, 0, 100);

            Vector3 inverseTransform = telekinesisRight.transform.InverseTransformDirection(telekinesisRight.force);

            int intensityX = Mathf.RoundToInt(map(inverseTransform.x, -200f, 200f, -100, 100));
            int clampedIntensityX = Mathf.Clamp(intensityX, -100, 100);

            
            if (time1 >= 0.025f && !channel1Sent)
            {
                EMSScript.sendMessage("C0I" + clampedIntensity + "T100G");
                channel1Sent = true;
            }
            else if (time1 >= timeOut)
            {
                EMSScript.sendMessage("C1I" + clampedIntensity + "T100G");
                time1 = 0;
                channel1Sent = false;
            }

            if (time2 >= timeOut)
            {
                if (intensityX >= 10)
                {
                    EMSScript2.sendMessage("C0I" + clampedIntensityX + "T100G");
                    time2 = 0;
                }
                else if (intensityX <= -10)
                {
                    EMSScript2.sendMessage("C1I" + Mathf.Abs(clampedIntensityX) + "T100G");
                    time2 = 0;
                }

                time2 = 0;
            }
        }
    }









}
