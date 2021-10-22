using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWithoutDiff : MonoBehaviour
{
    public float speed;
    public float diff;
    private float originalX;
    
    // Start is called before the first frame update
    void Start()
    {
        originalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < originalX - diff)
        {
            Destroy(gameObject);
        }
    }
}
