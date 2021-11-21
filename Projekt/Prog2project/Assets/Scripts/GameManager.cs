using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] platforms;
    
    public void GeneratePlatform()
    {
        //Debug.Log("Oke");
        GameObject go = Instantiate(platforms[Random.Range(0, platforms.Length)], Vector3.right * 8, Quaternion.identity);
        ScoreScript.scoreValue += 1000;
    }
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}