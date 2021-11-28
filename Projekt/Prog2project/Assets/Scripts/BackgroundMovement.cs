using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
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

        if (transform.position.x < originalX - diff)
        {
            transform.Translate(Vector3.right * diff);
        }
    }
}
