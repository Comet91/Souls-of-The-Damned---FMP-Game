using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorWave : MonoBehaviour
{
    public AudioSource audioclip;

    public bool entered;

    private bool checking = true;

    void Update()
    {
        if (checking == true)
        {
            entered = GameObject.Find("Game Start Trigger").GetComponent<GameStart>().audioHorrorWaveHasPlayed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (entered == false)
            {
                checking = false;

                entered = true;

                audioclip.Play();
            }
            else
            {
                Debug.Log("[!] Horror Wave has been marked as played. Entered Audio State: " + entered);
            }
        }
    }
}