using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gai : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = -10f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed,0);
    }

}
