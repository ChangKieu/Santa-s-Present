using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bang : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed=-10f;
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*speed;
    }
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 20f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
