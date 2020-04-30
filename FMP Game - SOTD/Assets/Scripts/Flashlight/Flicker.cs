using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField]
    private Light light;

    float minFlickerSpeed  = 0.1f;
    float maxFlickerSpeed  = 1.0f;
    float minLightIntensity = 0;
    float maxLightIntensity = 1;
    float minChance = 10.0f;
    float maxChance = 100.0f;
    bool flicker = true;

    /*
    void Update()
    {
        StartCoroutine(flickering());
        StartCoroutine(flickerChance());
    }
    */

    void FixedUpdate()
    {
        StartCoroutine(flickerChance());
        StartCoroutine(flickering());
        StartCoroutine(flickerChance());
    }

    IEnumerator flickering()
    {
        light.enabled = true;
        //light.intensity = Random.Range(minLightIntensity, maxLightIntensity);
        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        light.enabled = false;
        yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
    }

    IEnumerator flickerChance()
    {
        yield return new WaitForSeconds(Random.Range(minChance, maxChance));
    }

}
