using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFill : MonoBehaviour
{

    public Animator anim;
    public float maxWeight = 10;
    private bool increaseWeight;
    private float time;
    private Rigidbody rigidbody;
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
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WaterTower")
        {
            anim.SetFloat("Speed",1);
            increaseWeight = true;
        }
    }
}
