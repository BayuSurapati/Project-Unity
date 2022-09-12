using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : MonoBehaviour
{
    public float speed;
    private Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Direction = Player2Controller.instance.transform.position - transform.position;
        Direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player2HealthController.instance.damagePlayer();
            AudioMap.instance.Playsfx(6);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
