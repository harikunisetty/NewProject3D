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

    [Header("Components")]
    [SerializeField] Animator anim;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("E_Sword"))
        {
            GameManager.Instance.PlayerDamage(5f);
        }
    }
}
