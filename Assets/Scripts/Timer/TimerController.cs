using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float speed = 1.0f;
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
