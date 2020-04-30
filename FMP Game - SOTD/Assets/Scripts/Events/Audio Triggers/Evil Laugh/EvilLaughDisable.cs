using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLaughDisable : MonoBehaviour
{

    bool entered;

    //public AudioSource audioclip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (entered == false)
            {
                entered = true;

                transform.parent.GetComponent<AudioSource>().loop = false;

            }
        }
    }

}
