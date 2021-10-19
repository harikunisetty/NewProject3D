using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu<SettingsMenu>
{
    [Header("Volume")]
    [SerializeField] Slider volumeSlider;

    [Header("Vibrations")]
    [SerializeField] bool vibrations;
    [SerializeField] Text vibrationsText;

    [Header("Data")]
    [SerializeField] DataManager dataManager;

    protected override void Awake()
    {
        base.Awake();
        LoadData();

    }
    public void volumeController(float VolumeValue)
    {
        PlayerPrefs.SetFloat("Volume", VolumeValue);
    }
    public void Vibrations()
    {
        vibrations = !vibrations;
        vibrationsText.text = vibrations.ToString();
    }
    public override void BackButton()
    {
        base.BackButton();
    }
    private void LoadData()
    {
        if (volumeSlider == null || vibrationsText == null)
            return;
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        vibrationsText.text = PlayerPrefs.GetString("Vibration");
    }
}
