using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    private Vector3 position;

    public GameObject projectile;
    public float fireRate = 0.15f;
    private float fireTime;

    public float health = 50.0f;
    public float currentHealth;
    public float maxHealth = 100.0f;
    
    public float ammo = 100.0f;
    //public float ammoDecrease = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        /*GameManager.instance.SetMaxHealth(maxHealth);
        GameManager.instance.SetHealth(health);
        GameManager.instance.SetMaxAmmo(ammo);*/
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(Input.GetMouseButtonDown(1) && Time.time > fireTime)
        {
            if(ammo != 0)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                fireTime = Time.time + fireRate;
            }
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("LoseScene");
        }
        GameManager.instance.SetHealth(health);
    }

    
    public void Heal(float damage)
    {
        if (health >= 100)
        {
            SceneManager.LoadScene("WinScene");
        }
        health += damage;
        GameManager.instance.SetHealth(health);
    }
    
    
    public void increaseAmmo(float ammoIncrease)
    {
        if(ammo < 100)
        {
            ammo += ammoIncrease;
            if(ammo > 100)
            {
                ammo = 100;
            }
            GameManager.instance.SetAmmo(ammo);
        }
        
    }
}
