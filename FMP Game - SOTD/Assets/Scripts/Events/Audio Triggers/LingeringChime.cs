using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringChime : MonoBehaviour
{
    public AudioSource audioclip;

    public bool entered;

    private bool checking = true;

    void Update()
    {
        if (checking == true)
        {
            entered = GameObject.Find("Game Start Trigger").GetComponent<GameStart>().audioLingeringChimeHasPlayed;
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
                Debug.Log("[!] Lingering Chime has been marked as played. Entered Audio State: " + entered);
            }
        }
    }
}
