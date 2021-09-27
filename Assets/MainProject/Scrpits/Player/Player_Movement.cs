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

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        attackScr = gameObject.GetComponentInChildren<Player_sword_Attack>();

        Enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }
    void Start()
    {

    }
      void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.SimpleMove((moveDirection * moveSpeed) * Time.deltaTime);

        anim.SetFloat("Speed", moveDirection.z);
        anim.SetFloat("Direction", moveDirection.x);

        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Attack");
            Attack = false;
        }
        //Enemy 
        distance = Vector3.Distance(Enemy.position, transform.position);
        if (distance <= closeDirection)
            transform.LookAt(Enemy);

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
    void AttackOn()
    {
        attackScr.BoxCollider.enabled = true;
    }

    void AttackOff()
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
    }
}
