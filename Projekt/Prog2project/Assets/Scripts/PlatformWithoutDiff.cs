using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWithoutDiff : MonoBehaviour
{
    public float speed;
    public float diff;
    private float originalX;
    
    void Start()
    {
        originalX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < originalX)
        {
            ScoreScript.scoreValue += 1;
        }

        if (transform.position.x < originalX - diff)
        {
            Destroy(gameObject);
        }
    }
}
