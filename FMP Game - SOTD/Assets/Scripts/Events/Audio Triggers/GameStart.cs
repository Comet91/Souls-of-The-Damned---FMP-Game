using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //------------------------------------------------------------------------

    [SerializeField] private int timeLeft;
    [SerializeField] public int shardCollectedCount;

    [SerializeField] public bool audioScreamOneHasPlayed;
    [SerializeField] public bool audioEvilLaughHasPlayed;
    [SerializeField] public bool audioCreepyAmbienceHasPlayed;
    [SerializeField] public bool audioLingeringChimeHasPlayed;
    [SerializeField] public bool audioHorrorWaveHasPlayed;
    [SerializeField] public bool audioScarySirenHasPlayed;

    [SerializeField] public bool gameHasStarted;

    public GameObject[] shards;
    public ParticleSystem shardParticles;

    bool entered;

    public AudioSource audioclip;

    private AudioSource mainaudio;
    private AudioSource audioScreamOne;
    private AudioSource audioEvilLaugh;
    private AudioSource audioCreepyAmbience;

    private Text textObjective;
    private Text textShardsCollected;
    private Text textTimeLeft;
    private Text textYouLose;

    //------------------------------------------------------------------------

    private void Start()
    {
        audioEvilLaughHasPlayed = false;
        audioCreepyAmbienceHasPlayed = false;

        audioLingeringChimeHasPlayed = true;
        audioScreamOneHasPlayed = true;
        audioHorrorWaveHasPlayed = true;
        audioScarySirenHasPlayed = true;

        shards = GameObject.FindGameObjectsWithTag("Shard");

        foreach (GameObject shard in shards)
        {
            shard.GetComponent<MeshRenderer>().enabled = false;
            shardParticles = shard.GetComponentInChildren<ParticleSystem>();
            shardParticles.Stop();
        }

        textObjective = GameObject.Find("Objective").GetComponent<Text>();
        textShardsCollected = GameObject.Find("Shards Collected").GetComponent<Text>();
        textTimeLeft = GameObject.Find("Time Left").GetComponent<Text>();
        textYouLose = GameObject.Find("You Lose").GetComponent<Text>();

        textObjective.text = ("");
        textShardsCollected.text = ("");
        textTimeLeft.text = ("");
        textYouLose.text = ("");

        gameHasStarted = false;
    }

    private void Update()
    {

        // Checks if audio is playing, and if so, marks it as 'HasPlayed'

        audioScreamOne = GameObject.Find("Scream Trigger").GetComponent<AudioSource>();
        audioEvilLaugh = GameObject.Find("Evil Laugh Trigger").GetComponent<AudioSource>();
        audioCreepyAmbience = GameObject.Find("Creepy Ambience Trigger").GetComponent<AudioSource>();

        if (audioScreamOne.isPlaying)
        {
            audioScreamOneHasPlayed = true;
        }
        else if (audioEvilLaugh.isPlaying)
        {
            audioEvilLaughHasPlayed = true;
        }
        else if (audioCreepyAmbience.isPlaying)
        {
            audioCreepyAmbienceHasPlayed = true;
        }

        // Grabs shard Count from PlayerMovement Script

        shardCollectedCount = GameObject.Find("Player").GetComponent<PlayerMovement>().shardsCollected;

        if (shardCollectedCount == 19)
        {
            textObjective.text = ("OBJECTIVE: " + "<color=white>" + "COMPLETED" + "</color>");
            textShardsCollected.text = ("SHARDS COLLECTED: " + "<color=white>" + "19/19" + "</color>");
            textTimeLeft.text = ("TIME LEFT: <color=white>" + "ERROR" + "</color>");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        // Checking if all audio triggers have played, and if not the games goal won't start

        if (other.tag == "Player")
        {
            if (entered == false)
            {

                if (audioEvilLaughHasPlayed == true && audioCreepyAmbienceHasPlayed == true && !audioCreepyAmbience.isPlaying && !audioEvilLaugh.isPlaying)
                {
                    entered = true;

                    audioclip.Play();

                    //mainaudio = GameObject.Find("Player").GetComponent<AudioSource>();
                    //mainaudio.volume = 0f;

                    gameGoalStart();

                    /*
                    if (!audioclip.isPlaying)
                    {
                        mainaudio.volume = 0.51f;
                    }
                    */
                }   
            }
        }
    }

    private void gameGoalStart()
    {

        // Grabs all the shards and enables them with their particles

        shards = GameObject.FindGameObjectsWithTag("Shard");

        foreach (GameObject shard in shards)
        {
            shard.GetComponent<MeshRenderer>().enabled = true;
            shardParticles = shard.GetComponentInChildren<ParticleSystem>();
            shardParticles.Play();
        }

        shardCollectedCount = 0; // Counter Set

        // Enables the UI text

        textObjective.text = ("OBJECTIVE: " + "<color=white>" + "COLLECT ALL THE SHARDS. YOU BETTER HURRY, TIMES TICKING" + "</color>");
        textShardsCollected.text = ("SHARDS COLLECTED: " + "<color=white>" + "0/19" + "</color>");
        textTimeLeft.text = ("TIME LEFT: <color=white>" + "00:60" + "</color>");

        StartCoroutine(Countdown());

        gameHasStarted = true;

        // Post-game audio are now triggerable

        audioLingeringChimeHasPlayed = false;
        audioScreamOneHasPlayed = false;
        audioHorrorWaveHasPlayed = false;
        audioScarySirenHasPlayed = false;
    }

    // Lose Time
    IEnumerator Countdown()
    {
        while (true)
        {

            // Time Left/Countdown

            yield return new WaitForSeconds(1);
            timeLeft--;

            int min = Mathf.FloorToInt(timeLeft / 60);
            int sec = Mathf.FloorToInt(timeLeft % 60);
            textTimeLeft.text = ("TIME LEFT: " + "<color=white>" + min.ToString("00") + ":" + sec.ToString("00") + "</color>");

            textShardsCollected.text = ("SOUL SHARDS COLLECTED: " + "<color=white>" + shardCollectedCount + "/19" + "</color>");

            // If countdown hits 0, then UI Text Updates

            if (timeLeft <= 0)
            {
                textObjective.text = ("OBJECTIVE: " + "<color=white>" + "OBJECTIVE FAILED" + "</color>");
                textShardsCollected.text = ("SOUL SHARDS COLLECTED: " + "<color=white>" + "ERROR" + "</color>");
                textTimeLeft.text = ("TIME LEFT: <color=white>" + "ERROR" + "</color>");

                textYouLose.text = ("YOU LOSE");

                StartCoroutine(GameOver());
            }
        }
    }

    // Game Over

    IEnumerator GameOver()
    {
        // Freezes the game for 5 seconds, then restarts it.

        Time.timeScale = 0.00001f;
        audioclip.Stop();
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}
