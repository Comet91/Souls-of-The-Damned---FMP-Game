using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarySiren : MonoBehaviour
{
    public bool entered;

    private bool checking;

    void Update()
    {
        if (checking == true)
        {
            entered = GameObject.Find("Game Start Trigger").GetComponent<GameStart>().audioScarySirenHasPlayed;
        }
    }

    public AudioSource audioclip;

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
                Debug.Log("Audio has been marked as played. Audio State: " + entered);
            }
        }
    }
}
