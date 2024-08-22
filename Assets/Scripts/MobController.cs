using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class MobController : MonoBehaviour, Attackable
{

    [SerializeField] Transform playerPosition;
    public float speed;
    public float maxhealth = 100;
    public float currentHealth;

    public HealthBar healthBar;


    void Start()
    {
        currentHealth = maxhealth;
        healthBar.setMaxHealth(maxhealth);
    }
    // Update is called once per frame
    void Update()
    {
        /*
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
        */
    }
    public void attack() {
        currentHealth -= 20;
        healthBar.updateHealth(currentHealth);
        if (currentHealth == 0) {
            gameObject.SetActive(false);
        }
 
    }
}
