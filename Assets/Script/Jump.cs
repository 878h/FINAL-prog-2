using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Jumping via space. Can only jump once and touch ground to jump again
    public float jumpForce = 10f;
    public bool isOnGround = true;

    private Rigidbody playerRB;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        
        Physics.gravity *= 110f; 
    }

    // Update is called once per frame
    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}


