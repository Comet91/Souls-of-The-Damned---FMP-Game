using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public AudioSource audioclip;
    public bool alreadyPlayed;
    //public GameObject boxObject;

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!alreadyPlayed)
            {
                alreadyPlayed = true;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                StartCoroutine(pausefor());
            }
        }
    }

    IEnumerator pausefor()
    {
        yield return new WaitForSeconds(1);
        audioclip.Play();
    }
}