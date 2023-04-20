using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void Damage(int damage)
    {

        health -= damage;

    }

    public void addHealth(int AddHealth)
    {
     health += AddHealth;
     
     if (health >= 100)
        {
            health = 100;
        }
    }

}
