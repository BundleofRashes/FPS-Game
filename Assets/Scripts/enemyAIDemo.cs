using UnityEngine;

public class enemyAIDemo : MonoBehaviour
{
    [HideInInspector] public IdleStateDemo idleState;
    [HideInInspector] public AlertStateDemo alertState;
    [HideInInspector] public IEnemyStateDemo currentState;

    public Material myMaterial;     // Assign green to start, but will switch to red later
    public GameObject player;       // Drag your Player GameObject here in Inspector

    void Start()
    {
        // Initialize states
        idleState = new IdleStateDemo(this);
        alertState = new AlertStateDemo(this);

        currentState = idleState;
    }

    void Update()
    {
        currentState.UpdateState(); // Manually call UpdateState on current state
    }

    void OnTriggerEnter(Collider col)
    {
        currentState.OnTriggerEnter(col);
    }

    void OnTriggerStay(Collider col)
    {
        currentState.OnTriggerStay(col);
    }

    void OnTriggerExit(Collider col)
    {
        currentState.OnTriggerExit(col);
    }
}
