using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Aim : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }

    private void Update()
    {
        transform.right = (PointerPosition - (Vector2)transform.position).normalized;
    }

}
