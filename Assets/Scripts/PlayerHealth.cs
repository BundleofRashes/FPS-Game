using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float Health;
    private float lerpTimer; 
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Health = Mathf.Clamp(Health, 0, maxHealth);
        UpdateHealthUI();
        if(Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(Random.Range(5,10));
        }
    }
    public void UpdateHealthUI()
    {
        Debug.Log(Health); 
    }
    public void TakeDamage(float damage )
    {
        Health -= damage;
        lerpTimer = 0f; 
    }
}
