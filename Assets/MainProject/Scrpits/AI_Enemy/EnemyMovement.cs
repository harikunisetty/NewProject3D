using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle , Chase , Attack , Death
}
public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy")]

    [SerializeField] EnemyState State = EnemyState.Idle;

    [Header("Enemy")]
    [SerializeField] float chaseRange;
    [SerializeField] float attackRange=1.5f;

    [Header("Components")]
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigidbody;

    [Header("Scripts")]
    [SerializeField] SwordAttack attackScr;
    [SerializeField] AI_Health aiHealth;

    [Header("AI")]
    private NavMeshAgent agent;

    public float HitValue = 10f;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        aiHealth = GetComponent<AI_Health>();
    }

    void Start()
    {
        State = EnemyState.Idle;
      

    }
    void Update()
    {
        if (!GameManager.Instance.Player)
            return;

       

        switch (State)
        {
            case EnemyState.Idle:
                agent.isStopped = true;

                // Animation
                animator.SetFloat("Move", 0f);
                animator.SetBool("Attack", false);
                break;
            case EnemyState.Chase:
                agent.isStopped = false;

                agent.SetDestination(GameManager.Instance.Player.transform.position);

                // Animation
                animator.SetFloat("Move", rigidbody.velocity.y);
                animator.SetBool("Attack", false);
                break;
            case EnemyState.Attack:
                agent.isStopped = true;

                // Animation
                animator.SetFloat("Move", 0f);
                animator.SetBool("Attack", true);

                break;
            case EnemyState.Death:
                agent.isStopped = true;

                // Animation
                animator.SetFloat("Move", 0f);
                break;
            default:
                break;
        }
        if (PlayerInRange())
        {
            if (PlayerInAttackRange())
                State = EnemyState.Attack;
            else
                State = EnemyState.Chase;
        }
        else
            State = EnemyState.Idle;
    }
     bool PlayerInRange()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < chaseRange) 
            return true;
        else
            return false;
    }
   bool PlayerInAttackRange()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < attackRange)
            return true;
        else
            return false;
    }
    public void Death()
    {
        Debug.Log("AI Death");
        GameManager.Instance.PlayerScore(20);
        this.gameObject.SetActive(false);
    }

    void AttackOn()
    {
        attackScr.BoxCollider.enabled = true;
    }

    void AttackOff()
    {
        attackScr.BoxCollider.enabled = false;  
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerSword"))
        {
            aiHealth.AiDamage(10f);
        }
    }
}

