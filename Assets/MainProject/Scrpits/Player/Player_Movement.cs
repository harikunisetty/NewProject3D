using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] CharacterController controller;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] RaycastHit hit;
    private Vector3 targetDirection;
    private Ray ray;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.SimpleMove((moveDirection * moveSpeed) * Time.deltaTime);
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
        Vector3 direction = new Vector3(hit.point.x, transform.position.y, hit.point.y);
        Quaternion targetRotation = Quaternion.LookRotation(direction +transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
            
                  
    }
}
