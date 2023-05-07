using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    private EnemyReferences enemyReferences;

    private float distanceThreshold = 1.7f;
    private float pathUpdateDeadline;
    
    public GameObject enemy;
    public GameObject[] coins;

    public GameObject winPanel;
    public GameObject losePanel;

    private void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");

        winPanel = GameObject.FindGameObjectWithTag("Win");
        losePanel = GameObject.FindGameObjectWithTag("Lose");

        HideWin();
        HideLose();
    }

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();

    }

    private void Update()
    {
        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) < 1f;

            if (inRange)
            {
                LookAtTarget();
            } 
            else
            {
                UpdatePath();
            }

            //Check if the player and enemy are next to each other
            float distance = Vector3.Distance(target.transform.position, enemy.transform.position);
            if (distance <= distanceThreshold)
            {
                Debug.Log("Caught");
                ShowLose();
                // Stop the game by setting the timescale to 0
                Time.timeScale = 0f;
            }
        }

        for (int i = 0; i < coins.Length; i++)
        {
            if (coins[i] == null)
            {
                //Remove deleted coin from array
                coins = coins.Where(x => x != null).ToArray();

                //Increase enemy speed
                //Debug.Log("Enemy speed is: " + enemyReferences.agent.speed);
                enemyReferences.agent.speed += 1.5f;
                enemyReferences.agent.angularSpeed += 100f;
                //Debug.LogWarning("Enemy speed is: " + enemyReferences.agent.speed);
            }
        }

        if (coins.Length == 0)
        {
            Debug.Log("You win!");
            ShowWin();
            Time.timeScale = 0f;
        }
        //Current enemy speed
        
    }

    private void LookAtTarget()
    {
        Vector3 lookPosition = target.position - transform.position;
        lookPosition.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
        
    }

    private void UpdatePath()
    {
        if(Time.time >= pathUpdateDeadline)
        {
            //Debug.Log("Updating Path");
            pathUpdateDeadline = Time.time + enemyReferences.pathUpdateDelay;
            enemyReferences.agent.SetDestination(target.position);
        }
    }

    private void ShowWin()
    {
        winPanel.SetActive(true);
    }

    private void HideWin() 
    { 
        winPanel.SetActive(false);
    }

    private void ShowLose()
    {
        losePanel.SetActive(true);
    }

    private void HideLose()
    {
        losePanel.SetActive(false);
    }

}
