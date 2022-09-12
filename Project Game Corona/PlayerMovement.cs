using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float movespeed;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 8f;
    }

    public void MoveUp()
    {
        rb.velocity = Vector2.up * movespeed;
    }

    public void MoveDown()
    {
        rb.velocity = Vector2.up * -movespeed;
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
}
