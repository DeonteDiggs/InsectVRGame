using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement enemyMovement;
    public float moveSpeed = 0f;
    public Transform player;
    public bool isPlayerInEnemyZone = false; 

    NavMeshAgent navMeshAgent;

    [SerializeField] private int damageCount = 0;
    void Awake(){
    //     GameObject findPlayer = GameObject.Find("Player");
    //     player = findPlayer.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    void Update(){
        if (isPlayerInEnemyZone)
        {
            print("hit");
            MoveTowardsPlayer();
        }
    }

    public EnemyMovement(){}

    public void MoveTowardsPlayer(){
        // float distance = moveSpeed * Time.deltaTime;
        // this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.position.x, 1f, player.position.z), distance);
        
        navMeshAgent.SetDestination(player.position);
    }

    // void OnCollisionEnter(Collision collision){
    //     print(collision.gameObject);
    //     if (collision.gameObject.layer == 10)
    //     {   
    //         EnemyDeath();
    //     }
    // }

    void OnTriggerEnter(Collider other){

        if (other.gameObject.layer == 11)
        {
            EnemyDeath();
            
        }

        if(other.gameObject.layer == 9){
            MoveTowardsPlayer();
        }
    }

    private void EnemyDeath()
    {
        damageCount--;
        if (damageCount == 0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
