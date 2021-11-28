using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D jump;
    private Animator animator;
    private CircleCollider2D collider;
    public float timePassed;
    public int life = 4;
    public Image[] lives;

    void Start()
    {
        jump = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", true);
        collider = GetComponent<CircleCollider2D>();
        ScoreScript.scoreValue = PlayerPrefs.GetInt("ScoreValue");
    }

    void Update()
    {
        if (transform.position.y <= -5) {
            TakeLife(999);
            lives[0].enabled = false;
            lives[1].enabled = false;
            lives[2].enabled = false;
            lives[3].enabled = false;
        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            //animator.SetBool("Jump", true);
            jump.AddForce(Vector2.up * 400);
        }

        if (Input.GetKeyDown(KeyCode.F) && (Time.time - timePassed) >= 0.7)
        {
            timePassed = Time.time;
            animator.SetTrigger("Attack");
            foreach (RaycastHit2D enemyCast in Physics2D.CircleCastAll(collider.bounds.center, 2f, Vector2.right,
                1.01f)) {
                if (enemyCast.collider != null)
                {
                    if (enemyCast.collider.TryGetComponent<Enemy>(out Enemy enemy))
                    {
                        Destroy(enemy.gameObject);
                        ScoreScript.scoreValue += 2000;
                    }
                } 
            }
        }
        
        animator.SetBool("Jump", !IsGrounded());
    }

    public void TakeLife(int i) {
        life -= i;
        
        if (life > 0)
        {
            lives[life].enabled = false;
        }

        Debug.Log("Noob");
        if (life <= 0)
        {
            PlayerPrefs.SetInt("ScoreValue", ScoreScript.scoreValue / 1000);
            PlayerPrefs.Save();
            Debug.Log("Haha meghaltál");
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
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
