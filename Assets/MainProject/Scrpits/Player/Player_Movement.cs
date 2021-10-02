using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_Movement : MonoBehaviour
{
    [Header("Movement")]

    [SerializeField] float moveSpeed;
    [SerializeField] CharacterController controller;
    private Vector3 targetDirection;

    [Header("Ground")]

    [SerializeField] LayerMask groundLayer;
    [SerializeField] RaycastHit hit;
    private Ray ray;
    public bool Attack;

    [Header("Components")]
    [SerializeField] Animator anim;
    [SerializeField] Player_sword_Attack attackScr;

    [Header("EnmeyDirectionPoint")]
    public Transform Enemy;
    private float distance;
    public float closeDirection;

    [Header("Attack")]
    [SerializeField] bool isAttacking;
    [SerializeField] AttackType attackType;


    [Header("Special Attack")]
    [SerializeField] LayerMask splLayerMask;
    [SerializeField] bool canSplAttack01, canFireSplAttack01;
    [SerializeField] float delayTime = 3f;

    public enum AttackType
    {
        Normal, Attack, SPLAttack01
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        attackScr = gameObject.GetComponentInChildren<Player_sword_Attack>();

       
    }
    void Start()
    {
        isAttacking = false;
        canSplAttack01 = false;
        canFireSplAttack01 = true;
        attackType = AttackType.Normal;
    }
      void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.SimpleMove((moveDirection * moveSpeed) * Time.deltaTime);

        anim.SetFloat("Speed", moveDirection.z);
        anim.SetFloat("Direction", moveDirection.x);

       /* if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Attack");
            Attack = false;
        }*/
        //Enemy 
        distance = Vector3.Distance(Enemy.position, transform.position);
        if (distance <= closeDirection)
            transform.LookAt(Enemy);


        //Attacking

        if (Input.GetKeyDown(KeyCode.X) && isAttacking == false)
        {
            isAttacking = true;
            PlayerAttack();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isAttacking == false && canSplAttack01)
            {
                if (canFireSplAttack01)
                {
                    isAttacking = true;
                    canFireSplAttack01 = false;
                    PlayerAttack();
                }
            }
        }

    }
    private void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if( Physics.Raycast(ray,out hit,500f, groundLayer, QueryTriggerInteraction.Ignore) )
        {
            if (hit.point != targetDirection)
            {
                targetDirection = hit.point;
            }
        }
        Vector3 direction = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        Quaternion targetRotation = Quaternion.LookRotation(direction- transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
            
                  
    }
    void PlayerAttackOn()
    {
        //AttackOff
    }

    void PlayerAttackOff()
    {
        attackScr.BoxCollider.enabled = false;
        Debug.Log("Off");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("E_Sword"))
        {
            GameManager.Instance.PlayerDamage(10f);
            anim.SetTrigger("Damage");
            Attack = true;
        }

        if (other.CompareTag("SPLAttack01"))    
        {
            canSplAttack01 = true;
            Destroy(other.gameObject);
        }
        canSplAttack01 = true;
    }
    void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
            attackType = AttackType.Attack;
        else if (Input.GetKeyDown(KeyCode.C))
            attackType = AttackType.SPLAttack01;

        switch (attackType)
        {
            case AttackType.Attack:
                anim.SetTrigger("Attack");

                break;
            case AttackType.SPLAttack01:
                anim.SetTrigger("SPLAttack");

                Invoke("SPLDelayCallAttack", 0.525f);
                break;
            default:
                break;
        }

        isAttacking = false;
        attackType = AttackType.Normal;
    }

    void SPLDelayCallAttack()
    {
        CancelInvoke();

        var sphCollider = Physics.OverlapSphere(transform.position, 3.5f, splLayerMask);
        if (sphCollider.Length > 0)
        {
            foreach (var coll in sphCollider)
            {
                coll.gameObject.SetActive(false);
            }
        }

        Invoke("DelaySPLAttack", delayTime);
    }

    void DelaySPLAttack()
    {
        CancelInvoke();
        canFireSplAttack01 = true;
    }
}
