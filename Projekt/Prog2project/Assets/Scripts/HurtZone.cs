using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtZone : MonoBehaviour {
    private Player player;
    public int take = 1;
    public bool destroySelf;

    void Start() 
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            player.TakeLife(take);
            if(destroySelf) Destroy(gameObject);
        }
    }
}
