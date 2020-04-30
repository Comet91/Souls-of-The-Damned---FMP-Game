using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLaugh : MonoBehaviour
{

    public bool entered;

    void Update()
    {
        entered = GameObject.Find("Game Start Trigger").GetComponent<GameStart>().audioEvilLaughHasPlayed;
    }

    public AudioSource audioclip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (entered == false)
            {
                entered = true;

                audioclip.Play();

                audioclip.loop = true;
            }
            else
            {
                Debug.Log("Audio has been marked as played. Audio State: " + entered);
            }
        }
    }


}
