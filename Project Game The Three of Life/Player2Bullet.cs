using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Bullet : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D theRB;

    public GameObject impactEffect;

    public int damageToGive = 2;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy2Controller>().DamageEnemy(damageToGive);
        }
        

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
