using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyAmbience : MonoBehaviour
{

    bool entered;

    public AudioSource audioclip;

    public AudioSource otheraudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (entered == false)
            {
                entered = true;

                audioclip.Play();

                otheraudio = GameObject.Find("Player").GetComponent<AudioSource>();
                otheraudio.volume = 0.1f;

                if (!audioclip.isPlaying)
                {
                    otheraudio.volume = 0.51f;
                }
            }
        }
    }

}
