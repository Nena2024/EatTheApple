using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private GameObject player;

    private int currentPoint;
    private bool isNear = false;

    public GameManager gameManager;
    
   
    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemy = GetComponent<NavMeshAgent>();
      
        enemy.autoBraking = false; // makes the agent stops in the corners 
        
        currentPoint = 0;
        enemy.destination = points[currentPoint].transform.position;
    
    }


    void Update()
    {
        
        if(gameManager.isGameActive==true)
        {
            // if the destination of the enemy and the player is less than 8 , enemy chases the player 
            if (Vector3.Distance(this.transform.position, player.transform.position) <= 8f)
            {

                LookTowardPlayer();
                isNear = true;

                enemy.destination = player.transform.position;
            }
            // if the destination of the enemy and the player is biggar than  8 , the enemy goes to the next set point 
            if (Vector3.Distance(this.transform.position, player.transform.position) > 8f)
            {
               
                EnemyRotate();
                enemy.destination = points[currentPoint].transform.position;
            }
            //if the current positon of the enemy and the next point is less than 2 , it goes to the next point
            if (Vector3.Distance(this.transform.position, points[currentPoint].transform.position) <= 2f)
            {
                GoToNext();
            }
           
        }
        
    }

    //going toward the next positon of the target points 
    void GoToNext()
    {

        if (currentPoint < points.Length - 1)
        {
           

            currentPoint++;
           
        }
        else
        {
            currentPoint = 0;
        }
        enemy.destination = points[currentPoint].transform.position;


    }
    void EnemyRotate() // the rotation of enemy when going toward the  next point 
    {
        Vector3 targetDirection = points[currentPoint].transform.position - this.transform.position;
        float step = 2.0f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    void LookTowardPlayer()// the ortation of the enem when going toward the player 
    {
        Vector3 targetDirection = player.transform.position - points[currentPoint].transform.position;
        float step = 1.0f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    void OnCollisionEnter(UnityEngine.Collision collision) // if stuck in a place 
    {
        if (collision.gameObject.CompareTag("Wall") && isNear)
        {
          
            enemy.destination = points[points.Length-1].transform.position;
            isNear = false;

        }

    }
}
