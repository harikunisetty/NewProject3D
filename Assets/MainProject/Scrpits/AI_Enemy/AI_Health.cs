using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Health : MonoBehaviour
{

    [Header("AIHealth")]

    [SerializeField] float AIHealth;
    private float maximumAiHealth = 100f;
    void Start()
    {

        AIHealth = maximumAiHealth;
    }
    public void AiDamage(float hitvalue)
    {
        if (AIHealth > 0f)
        {
            AIHealth -= hitvalue;
            UiManager.Instance.AiHealthUI(AIHealth);

            if (AIHealth <= 0f)
                EnemyDead();
        }
        else
        {
            EnemyDead();
        }
    }
  
    public void EnemyDead()
    {
        Destroy(gameObject);
    }
}
