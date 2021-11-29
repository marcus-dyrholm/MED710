using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EMSTestScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    public EMSScript eMSScript1;
    public EMSScript2 eMSScript2;
    public Slider intensitySlider;

    public int duration;
    public int savedDuration;
    public Text intensityText;

    private float intensity;

    public int channel;

    public bool toggle;
    public bool toggleSingle;

    private float time;
    private bool channel1Sent;

    private void Start()
    {
        savedDuration = duration;
    }

    void FixedUpdate()
    {
        if (toggle)
        {
            time += Time.deltaTime;
            duration = 100;


                if (time >= 0.050f && !channel1Sent)
                {
                    eMSScript1.sendMessage("C0I" + intensity + "T200G");
                    channel1Sent = true;
                    //Debug.Log("C0I" + intensity + "T500G");
                }
                else if (time >= + 0.10f)
                {
                    eMSScript1.sendMessage("C1I" + intensity + "T200G");
                    //Debug.Log("C1I" + intensity + "T500G");
                    time = 0;
                    channel1Sent = false;

                }
            
        }
        else
        {
            duration = savedDuration;
        }

        if (toggleSingle)
        {
            duration = 100;
            time += Time.deltaTime;
            if (time>= 0.25f)
            {
                sendMessageToChannel();
                time = 0;
            }
            
        }
        else
        {
            duration = savedDuration;
        }
    }

    public void ToggleBool(bool isOn)
    {
        toggle = isOn;
    }

    public void ToggleSingle(bool isOn)
    {
        toggleSingle = isOn;
    }

    public void setIntensity(float intens)
    {
        intensity = Mathf.RoundToInt(intens * 100);
        intensityText.text = "Intensity = " + intensity;
    }
    public void sendMessageToBoth()
    {
        
        //for triceps testing
        eMSScript1.sendMessage("C0I" + intensity + "T" + duration + "G");
        eMSScript1.sendMessage("C1I" + intensity + "T" + duration + "G");
        Debug.Log("sentMessageToBoth");
    }

    public void sendMessageToChannel()
    {
        
        //for shoulder testing
        if (channel == 0)
        {
            eMSScript2.sendMessage("C0I" + intensity + "T" + duration + "G");
            Debug.Log("C0I" + intensity + "T" + duration + "G");
        }

        if (channel == 1)
        {
            eMSScript2.sendMessage("C1I" + intensity + "T" + duration + "G");
            Debug.Log("C1I" + intensity + "T" + duration + "G");
        }
        
        
    }

    public void SendMessageToChannel(int EMSNum, int channel, int intensity, int duration)
    {

        if (EMSNum == 1)
        {
            eMSScript1.sendMessage("C" + channel + "I" + intensity + "T" + duration + "G");
        }
        else if (EMSNum == 2)
        {
            eMSScript2.sendMessage("C" + channel + "I" + intensity + "T" + duration + "G");
        }


    }
}
