using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarySiren : MonoBehaviour
{
    public AudioSource audioclip;

    public bool entered;

    private bool checking = true;

    void Update()
    {
        if (checking == true)
        {
            entered = GameObject.Find("Game Start Trigger").GetComponent<GameStart>().audioScarySirenHasPlayed;
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
                Debug.Log("[!] Scary Siren has been marked as played. Entered Audio State == " + entered);
            }
        }
    }
}
