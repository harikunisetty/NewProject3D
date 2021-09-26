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
    public bool IsGameOver { get => isGameOver;}

    [Header("Game")]
    private bool isGameOver;
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
       /* playerHealth = maximumPlayerHealth;*/

        isGameOver = false;
    }

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
        isGameOver = true;
    }
}
