using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject player;
    public GameObject Player
    {
        get { return player; }
    }
    void Awake()
    {
        if (Instance != null)
        {

            DestroyImmediate(this.gameObject);
            return;
        }
        else
            Instance = this;

    }
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
