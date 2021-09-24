using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sword_Attack : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    public BoxCollider BoxCollider { get => boxCollider; set => boxCollider = value; }
    void Awake()
    {
        BoxCollider = GetComponent<BoxCollider>();
        BoxCollider.enabled = true;
    }


    void Update()
    {

    }
}
