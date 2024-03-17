using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 3.0f;

    public float moveSpeed = 350.0f;

    public float damage = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += Time.deltaTime * moveSpeed * transform.forward;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
