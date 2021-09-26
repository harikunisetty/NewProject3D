using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    public BoxCollider BoxCollider { get => boxCollider; set => boxCollider = value; }
    void Awake()
    {
        BoxCollider = GetComponent<BoxCollider>();
        BoxCollider.enabled = false;
    }

    
    void Update()
    {

    }
}
