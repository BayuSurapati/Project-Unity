using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float enemySpeed;

    public float rangeToChasePlayer;
    private Vector3 moveDirection;

    public int health = 6;
    public  GameObject[] deathSplatters;
    public GameObject hitEffect;

    public bool shouldShoot;
    public GameObject bullet;

    public Transform firePoint;
    public float fireRate;
    private float fireCounter;

    public float shootRange;

    public Animator anim;

    public SpriteRenderer theBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(theBody.isVisible && Player2Controller.instance.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position, Player2Controller.instance.transform.position) < rangeToChasePlayer)
            {
                moveDirection = Player2Controller.instance.transform.position - transform.position;
            }
            else
            {
                moveDirection = Vector3.zero;
            }
            moveDirection.Normalize();

            theRB.velocity = moveDirection * enemySpeed;



            if (shouldShoot && Vector3.Distance(transform.position, Player2Controller.instance.transform.position)<shootRange)
            {
                fireCounter -= Time.deltaTime;

                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                }
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }

        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        Instantiate(hitEffect, transform.position, transform.rotation);
        AudioMap.instance.Playsfx(5);

        if(health <= 0)
        {
            AudioMap.instance.Playsfx(3);

            Destroy(gameObject);

            int SelectedSplatters = Random.Range(0, deathSplatters.Length);

            int rotation = Random.Range(0, 4);

            Instantiate(deathSplatters[SelectedSplatters], transform.position, Quaternion.Euler(0f,0f,rotation * 90));

            //Instantiate(deathSplatters, transform.position, transform.rotation);
        }
    }
}
