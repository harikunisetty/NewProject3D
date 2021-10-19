    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    [SerializeField] bool isobjectiveCompleted;

    public bool IsObjectiveCompleted
    {
        get { return isobjectiveCompleted; }
    }
    private void Start()
    {
        isobjectiveCompleted = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isobjectiveCompleted = true;
        }
    }
}
