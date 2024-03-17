using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public Slider healthBarSlider;
    public Slider ammoSlider;
    public static GameManager instance = null;
    public GameObject player;

    // Awake Checks - Singleton setup
    void Awake() {

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    public void SetMaxHealth(float health)
    {
        healthBarSlider.maxValue = health;
        healthBarSlider.value = health;
    }

    public void SetHealth(float health)
    {
        healthBarSlider.value = health;
    }

    public void SetMaxAmmo(float ammo)
    {
        ammoSlider.maxValue = ammo;
        ammoSlider.value = ammo;
    }

    public void SetAmmo(float ammo)
    {
        ammoSlider.value = ammo;
    }
}
