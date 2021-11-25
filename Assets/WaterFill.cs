using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFill : MonoBehaviour
{

    public Animator anim;
    public float maxWeight = 10;
    private bool increaseWeight;
    public float minWeight = 3;
    private float time;
    private Rigidbody rigidbody;
    private bool decreaseWeight;
    public GameObject waterSpout;
    // Start is called before the first frame update
    void Start()
    {
        time = this.GetComponent<Rigidbody>().mass;
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(increaseWeight == true)
        {
            time += Time.deltaTime;

            rigidbody.mass = time;
            
            if (time >= maxWeight)
            {
                increaseWeight = false;
            }
        }
        else if(decreaseWeight == true)
        {
            time -= (Time.deltaTime / 2);
            rigidbody.mass = time;

            if(time <= minWeight)
            {
                decreaseWeight = false;
                waterSpout.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WaterTower")
        {
            anim.SetFloat("Speed",1);
            increaseWeight = true;
            decreaseWeight = false;
            waterSpout.SetActive(true);
        }
    }

    void OnTriggerExit()
    {
        decreaseWeight = true;
        increaseWeight = false;
        anim.SetFloat("Speed", -0.5f);
        
    }
}
