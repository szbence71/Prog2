using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
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
        // deltaTime előző képkocka óta eltelt idő, hogy minden fps-en konzisztensen mozogjon
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < originalX - diff)
        {
            transform.Translate(Vector3.right * diff); // azé me 1 a right és 1 * diff az diff
        }
    }
}
