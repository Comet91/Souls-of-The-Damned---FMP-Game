using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour  
{

    [SerializeField] 
    private Light light;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (light.enabled == false)
            {
                light.enabled = true;
            }
            else if (light.enabled == true)
            {
                light.enabled = false;
            }
        }

    }
}
