using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 1;
    public AudioClip healthPickup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player" && Player2HealthController.instance.currentHealth <= 5)
        {
            Player2HealthController.instance.healPlayer(healAmount);
            AudioSource.PlayClipAtPoint(healthPickup, transform.position);
            Destroy(gameObject);
        }
    }
}
