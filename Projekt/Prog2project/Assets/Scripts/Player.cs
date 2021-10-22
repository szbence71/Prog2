using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D jump;
    private Animator animator;
    private CircleCollider2D collider;
    
    void Start()
    {
        jump = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", true);
        collider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            //animator.SetBool("Jump", true);
            jump.AddForce(Vector2.up * 400);
        }
        
        animator.SetBool("Jump", !IsGrounded());
    }

    bool IsGrounded()
    {
        float extraHeightText = .01f;
        RaycastHit2D groundCheck = Physics2D.Raycast(collider.bounds.center, Vector2.down, collider.bounds.extents.y + extraHeightText);
        Debug.DrawRay(collider.bounds.center, Vector2.down * (collider.bounds.extents.y + extraHeightText), Color.green);
        //if(groundCheck.collider != null) Debug.Log($"{groundCheck.collider.gameObject.name}");

        return groundCheck.collider != null;
    }
}
