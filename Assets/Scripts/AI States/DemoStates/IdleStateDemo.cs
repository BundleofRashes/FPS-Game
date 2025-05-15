using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateDemo : IEnemyStateDemo
{
    enemyAIDemo myEnemy;

    // When we call the constructor, we save
    // a reference to our enemy's AI
    public IdleStateDemo(enemyAIDemo enemy)
    {
        myEnemy = enemy;
    }

    // Here goes all the functionality that we want
    // what the enemy does when in this state.
    public void UpdateState()
    {
        myEnemy.myMaterial.color = Color.green;
    }

    public void GoToAlertState()
    {
        myEnemy.currentState = myEnemy.alertState;
    }

    // Since we are already in the Idle state, 
    // we will never call this function from
    // here
    public void GoToIdleState() { }


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            GoToAlertState();
    }

    // In the Idle state, as the player is
    // outside the trigger we won't do anything
    public void OnTriggerStay(Collider col)
    {
    Debug.Log("Trigger entered by: " + col.gameObject.name); // 🔍

    if (col.CompareTag("Player"))
    {
        Debug.Log("Player detected! Switching to Alert.");
        GoToAlertState();
    }
    }
    public void OnTriggerExit(Collider col) 
    { 
        Debug.Log("IdleState: something exited the trigger");
    }
}
