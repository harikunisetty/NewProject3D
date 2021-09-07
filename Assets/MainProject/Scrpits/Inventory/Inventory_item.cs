using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_item : MonoBehaviour
{
   public enum ItemType
    {
        Box,
        CapSule,
        Sphere,
        Cylinder
    }

    [SerializeField] ItemType type;
    public Sprite itemIcon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryManagement.Instance.AddItem(this.gameObject);
        }
    }
}
