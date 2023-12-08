using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScipts : MonoBehaviour
{
    Transform target;
    Vector3 velocity;
    [Range(0, 1)]
    [SerializeField] float smoothTime;
    [SerializeField] Vector3 pos;
    [SerializeField] float xLimit;
    [SerializeField] Vector2 yLimit;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void LateUpdate()
    {
        Vector3 targetPos = target.position+pos;
        targetPos = new Vector3(Mathf.Clamp(targetPos.x, xLimit, targetPos.x), Mathf.Clamp(targetPos.y, yLimit.x, yLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        //transform.position = Vector3.Lerp(transform.position, target.position + pos, smoothTime);

    }
}
