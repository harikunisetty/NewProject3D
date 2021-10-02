using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("PlayerHealth")]

    [SerializeField] float playerHealth;
   /* private float maximumPlayerHealth = 100f;*/
    [SerializeField] GameObject player;
    [SerializeField] Player_Movement playerController;
    public GameObject Player
    {
        get { return player; }
    }
    public float PlayerHealth { get => playerHealth; }
    public bool IsGameOver { get => isGameOver;}

    [Header("Game")]
    private bool isGameOver;
    [Header("level")]
    [SerializeField] LevelObject levelObject;
    [SerializeField] string nextLevelName;
    [SerializeField] int nextLevelIndex;
    void Awake()
    {
        if (Instance != null)
        {

            DestroyImmediate(this.gameObject);
            return;
        }
        else
            Instance = this;
        /*DontDestroyOnLoad(this.gameObject);*/

    }
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        /* playerHealth = maximumPlayerHealth;*/
        playerController = player.GetComponent<Player_Movement>();
        levelObject = Object.FindObjectOfType<LevelObject>();
        isGameOver = false;
    }
    private void Update()
    {
        if(levelObject!=null&& levelObject.IsObjectiveCompleted)
        {
            LevelEnded();
        }
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
    void LevelEnded()
    {
        if (playerController != null)
        {
            playerController.enabled = false;

            player.GetComponent<CharacterController>().SimpleMove(Vector3.zero);
            LoadNextLevel(nextLevelIndex);
        }
    }
    void LoadNextLevel(int Index)
    {
        SceneManager.LoadScene(Index);
    }
    void LoadNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
