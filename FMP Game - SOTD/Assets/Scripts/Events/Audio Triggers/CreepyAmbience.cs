using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyAmbience : MonoBehaviour
{

    public bool entered;

    private void Update()
    {
        entered = GameObject.Find("Game Start Trigger").GetComponent<GameStart>().audioCreepyAmbienceHasPlayed;
    }

    public AudioSource audioclip;

    public AudioSource otheraudio;

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("Audio State: " + entered);

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
            else
            {
                Debug.Log("Audio has been marked as played. Audio State: " + entered);
            }
        }
    }

}
