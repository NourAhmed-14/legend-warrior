using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_states : MonoBehaviour
{
    [SerializeField]
    float maxHealth=100;
   public float power =10;
    int killScore = 200;
    public float currentHealth {  get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth= maxHealth;

    }
    public void ChangeHealth(float value)
    {
        // currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        Debug.Log("current health" + currentHealth + '/' + maxHealth);
        if(currentHealth <= 0) {
            Die(); 
        }

        void Die()
        {
            if(transform.CompareTag("Player"))
            {
// game over
            }
            else if (transform.CompareTag("Enemy"))
            {
                LevelManager.instance.score += killScore;
                Destroy(gameObject);
                //destroy enemy
            }
        }
    }

}