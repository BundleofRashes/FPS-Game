using UnityEngine;

public class AlertStateDemo : IEnemyStateDemo
{
    private enemyAIDemo myEnemy;

    // Constructor — saves a reference to the enemy AI brain
    public AlertStateDemo(enemyAIDemo enemy)
    {
        myEnemy = enemy;
    }

    // Called every frame from enemyAIDemo.Update()
    public void UpdateState()
    {
        Debug.Log("🟥 ALERT STATE ACTIVE — turning red");
        myEnemy.myMaterial.color = Color.red;
    }

    // Already in Alert — do nothing
    public void GoToAlertState() { }

    // Transition back to Idle
    public void GoToIdleState()
    {
        Debug.Log("🟩 Returning to IDLE state");
        myEnemy.currentState = myEnemy.idleState;
    }

    // Not used — player is already inside
    public void OnTriggerEnter(Collider col) { }

    // Rotate to face the player while they're inside the zone
    public void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Vector3 lookDirection = col.transform.position - myEnemy.transform.position;
            lookDirection.y = 0f; // Only rotate on Y axis

            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            myEnemy.transform.rotation = Quaternion.Slerp(
                myEnemy.transform.rotation,
                rotation,
                Time.deltaTime * 3f // smoother turn
            );
        }
    }

    // When the player leaves the sphere, return to idle
    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("🚶‍♂️ Player exited — switching to IDLE");
            GoToIdleState();
        }
    }
}
