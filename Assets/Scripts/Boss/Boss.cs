using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float speed = 3f;
    bool isRight = true;
    public GameObject[] curr;
    int nextPoint = 0;
    GameObject next;

    // Start is called before the first frame update
    void Start()
    {
        next = curr[0];

    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        if (transform.position == next.transform.position)
        {
            nextPoint++;
            if (nextPoint >= curr.Length) nextPoint = 0;
            next = curr[nextPoint];
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, next.transform.position, speed * Time.deltaTime);
        }

        if (isRight && transform.position.x < next.transform.position.x)
        {
            Flip();
            isRight = false;
        }
        else if (isRight == false && transform.position.x > next.transform.position.x)
        {
            Flip();
            isRight = true;
        }
    }
    void Flip()
    {

        transform.Rotate(0f, 180f, 0f);
    }
}
