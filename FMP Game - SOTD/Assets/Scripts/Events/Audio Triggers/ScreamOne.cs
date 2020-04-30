using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamOne : MonoBehaviour
{
    [SerializeField]
    int flickeramount;

    [SerializeField]
    public GameObject bloodstuff;

    [SerializeField]
    public int textAmount;

    public bool entered;

    public AudioSource audioclip;

    void Start()
    {
        // This makes the text invisble when the game starts

        for (int i = 0; i < textAmount; i++)
        {
            bloodstuff.transform.Find("GOB" + i).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        entered = GameObject.Find("Game Start Trigger").GetComponent<GameStart>().audioScreamOneHasPlayed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (entered == false)
            {
                entered = true;

                StartCoroutine(flickering());

                audioclip.Play();

                // This makes the text visble when you enter the trigger

                for (int i = 0; i < textAmount; i++)
                {
                    bloodstuff.transform.Find("GOB" + i).GetComponent<MeshRenderer>().enabled = true;
                }

                // This makes the flashlight flicker when entering the trigger

                IEnumerator flickering()
                {
                    int length = flickeramount;

                    for (int i = 0; i < length; i++)
                    {
                        float minFlickerSpeed = 0.1f;
                        float maxFlickerSpeed = 0.2f;

                        other.GetComponentInChildren<Light>().enabled = false;
                        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
                        other.GetComponentInChildren<Light>().enabled = true;
                        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
                    }

                    // Turns flashlight off after flickering loop runs, no matter whether you had it on or off before the trigger

                    other.GetComponentInChildren<Light>().enabled = false;
                }
            }
            else
            {
                Debug.Log("Audio has been marked as played. Audio State: " + entered);
            }
        }
    }

}
