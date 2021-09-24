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


    [Header("AIHealth")]

    [SerializeField] float AIHealth;
    private float maximumAiHealth = 100f;
    [SerializeField] GameObject Ai_Enemy;
   
    public float AiHealth
    {
        get => AiHealth;
    }
    public GameObject Ai_Enemy1 { get => Ai_Enemy;}
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
        Ai_Enemy = GameObject.FindGameObjectWithTag("Enemy");
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
        Debug.Log("Player Dead");
        isGameOver = true;
    }

    public void AiDamage(float HitValue)
    {
        if (AIHealth > 0f)
        {
            AIHealth -= HitValue;
            UiManager.Instance.AiHealthUI(AIHealth);

            if (AIHealth <= 0f)
                AiDead();
        }
        else
        {
            AiDead();
        }
    }
    public void AiDead()
    {
        Debug.Log("Ai Dead");
        
    }
}
