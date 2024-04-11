using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //basic player and game contrl
    private AudioSource sound; //for sound
    private int count; //score
    private float movementX; //player movement
    private float movementY; //^^^^
    public float speed = 0; //public edit speed of player
    public TextMeshProUGUI countText; //to display score

    private List<Vector3> currentPath; //path finding 
    private int currentPathIndex = 0;
    private bool isFollowingPath = false;

    public CollectiblePlacement collectiblePlacement; //collectible placement incomplete

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>(); //loop sound throughout game
        count = 0; //above
        SetCountText(); //above prv count
        currentPath = new List<Vector3>(); //pathfinding
        collectiblePlacement.GenerateCollectibles(); //incomplete
    }

    void OnMove(InputValue movementValue) //movement vvvvvvv
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    } // movement ^^^^

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); //score for the collectible which is not complete
    }

    private void FixedUpdate()
    { //player movement info vvvvv
        if (!isFollowingPath)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }

    }
}

   
