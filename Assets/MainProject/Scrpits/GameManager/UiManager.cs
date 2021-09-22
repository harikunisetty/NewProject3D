using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    [SerializeField] Image pHealthFill;
    void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    // Update is called once per frame
    public void PlayerHealthUI(float value)
    {
        pHealthFill.fillAmount = value * 0.01f;
    }
}
