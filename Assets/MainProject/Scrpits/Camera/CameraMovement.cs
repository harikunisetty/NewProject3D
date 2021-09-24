using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform playerTrans;
    [SerializeField] Vector3 camOffset;

    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camOffset = transform.position - playerTrans.position;
    }

    void LateUpdate()
    {
        /*if (playerTrans != null)
            return;*/
        transform.position = Vector3.Slerp(transform.position,
                              ( new Vector3(camOffset.x + playerTrans.position.x, transform.position.y, camOffset.z + playerTrans.position.z)),
                              speed);
    }
}
