using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityMultiplier;
    public bool onGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround){
            playerRB.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
            onGround = true;
        }
        if(collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            Debug.Log("GameOver");
        }
    }
}
