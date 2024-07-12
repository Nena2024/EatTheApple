using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    [SerializeField] private float speed = 50.0f;
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    public AudioClip collisionSound;
    public GameManager gameManager;
    private int pointValue=5;
    bool alreadyRight= true;
    bool alreadyLeft = false;
    bool alreadyUp = false;
    bool alreadyDown = false;
    bool alreadyWon = false;
    private int appleCounter=0;
   


    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive==true)
        {
            

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            // moving right and left and rotation of the player 

            if (Input.GetKey(KeyCode.LeftArrow) && alreadyRight && !alreadyUp && !alreadyDown)
            {
                playerRb.transform.Rotate(0, -180, 0);
                alreadyLeft = true;
                alreadyRight = false;

            }
            else if (Input.GetKey(KeyCode.LeftArrow) && alreadyDown)
            {
                playerRb.transform.Rotate(0, 90, 0);
                alreadyLeft = true;
                alreadyDown = false;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && alreadyDown)
            {
                playerRb.transform.Rotate(0, -90, 0);
                alreadyRight = true;
                alreadyDown = false;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && alreadyLeft && !alreadyUp && !alreadyDown)
            {
                playerRb.transform.Rotate(0, 180, 0);
                alreadyLeft = false;
                alreadyRight = true;

            }
            else if (Input.GetKey(KeyCode.UpArrow) && alreadyLeft)
            {
                playerRb.transform.Rotate(0, 90, 0);
                alreadyLeft = false;
                alreadyUp = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && alreadyUp && !alreadyRight)
            {
                playerRb.transform.Rotate(0, 90, 0);
                alreadyRight = true;
                alreadyUp = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && alreadyUp && !alreadyLeft)
            {

                playerRb.transform.Rotate(0, -90, 0);
                alreadyLeft = true;
                alreadyUp = false;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && !alreadyUp && alreadyRight)
            {
                playerRb.transform.Rotate(0, -90, 0);
                alreadyDown = false;
                alreadyUp = true;
                alreadyRight = false;
            }
            else if(Input.GetKey(KeyCode.UpArrow)&& alreadyDown)
            {
                playerRb.transform.Rotate(0, 180, 0);
                alreadyDown = false;
                alreadyUp = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && !alreadyDown && alreadyRight)
            {
                playerRb.transform.Rotate(0, 90, 0);
                alreadyRight = false;
                alreadyDown = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && !alreadyDown && alreadyLeft)
            {
                playerRb.transform.Rotate(0, -90, 0);
                alreadyLeft = false;
                alreadyDown = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && alreadyUp)
            {
                playerRb.transform.Rotate(0, 180, 0);
                alreadyDown = true;
                alreadyUp = false;
            }

            playerRb.AddForce(Vector3.right * horizontalInput * speed);
            playerRb.AddForce(Vector3.forward * verticalInput * speed);


        }
        //wining condition 
        if (appleCounter ==176)
        {
            alreadyWon = true;
            gameManager.WinGame();

        }

    }
    //if the player enter the enemy's collider , the game is over  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy")&&!alreadyWon)
        {
            gameManager.GameOver();
            gameManager.isGameActive = false;

        }
            
    }
    // if the player encounter apples  
    private void OnTriggerEnter(Collider other)
    {
        playerAudio.PlayOneShot(collisionSound, 1.0f);
        Destroy(other.gameObject);
        gameManager.UpdateScore(pointValue);
        appleCounter++;
     
    }
   
}
   
