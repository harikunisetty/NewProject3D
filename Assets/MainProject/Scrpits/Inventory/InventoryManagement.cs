using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagement : MonoBehaviour
{
    public static InventoryManagement Instance;
    [SerializeField] RectTransform itemList;
    [SerializeField] List<GameObject> itemObject = new List<GameObject>(4);
    void Start()
    {
        if (Instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        else
            Instance = this;
    }

    public void AddItem(GameObject item)
    {
        foreach (Collider collider in item.GetComponents<Collider>()) collider.enabled = false;
        foreach (MeshRenderer mr in item.GetComponents<MeshRenderer>()) mr.enabled = false;
        for (int i = 0; i <= Instance.itemList.childCount; i++)
        {
            Transform ChItem = Instance.itemList.GetChild(i);
            if (!ChItem.gameObject.activeSelf)
            {
                ChItem.GetComponent<Image>().sprite = item.GetComponent<Inventory_item>().itemIcon;
                ChItem.gameObject.SetActive(true);
                itemObject.Add(item);
                return;
            }
        }
    }

}
