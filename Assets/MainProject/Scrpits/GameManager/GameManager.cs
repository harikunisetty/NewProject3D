using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("PlayerHealth")]

    [SerializeField] float playerHealth;
    private float maximumPlayerHealth = 100f;
    [SerializeField] GameObject player;

    public GameObject Player
    {
        get { return player; }
    }

    public float PlayerHealth { get => playerHealth; }

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
    public void PlayerDamage(float value)
    {
        if (PlayerHealth > 0f)
        {
            playerHealth -= value;
            UiManager.Instance.PlayerHealthUI(playerHealth);

            if (PlayerHealth <= 0f)
                PlayerDead();
        }
        else
        {
            PlayerDead();
        }



    }

    public void PlayerDead()
    {
        Debug.Log("Player Dead");
    }
}
