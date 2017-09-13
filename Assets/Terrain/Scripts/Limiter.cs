using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limiter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("enemy"))
        {
            
            if (other.gameObject.tag == "enemy_normal_off")
            {
                other.gameObject.tag = "enemy_normal";
            }
            else if (other.gameObject.tag == "enemy_explosive_off")
            {
                other.gameObject.tag = "enemy_explosive";
            }
            else if (other.gameObject.tag == "enemy_giant_off")
            {
                other.gameObject.tag = "enemy_giant";
            }
        }
    }
}
