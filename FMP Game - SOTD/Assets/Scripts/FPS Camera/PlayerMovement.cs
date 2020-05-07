using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;

    private float vertInput;
    private float horizInput;
    private float movementSpeed;

    public bool gameStarted;

    public int shardsCollected;

    public ParticleSystem shardParticles;

    private CharacterController charController;

    private void Start()
    {
        shardsCollected = 0;
    }

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMove();

        gameStarted = GameObject.Find("Game Start Trigger").GetComponent<GameStart>().gameHasStarted;
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
        }
        else
        {
            movementSpeed = walkSpeed;
        }

        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shard") && gameStarted == true)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;

            other.gameObject.tag = "Collected";

            shardParticles = other.GetComponentInChildren<ParticleSystem>();
            shardParticles.Stop();

            shardsCollected++;

            Debug.Log(other.name + " has been collected!");
        }
    }

}