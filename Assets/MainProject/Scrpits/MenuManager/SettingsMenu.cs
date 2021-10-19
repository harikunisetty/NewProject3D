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
        //PlayerPrefs.SetFloat("Volume", VolumeValue);
        if (dataManager != null)
            dataManager.Volume = VolumeValue;
    }
    public void Vibrations()
    {
        vibrations = !vibrations;
        vibrationsText.text = vibrations.ToString();

        if (dataManager != null)
            dataManager.Vibrations = vibrations;
    }
    public override void BackButton()
    {
        base.BackButton();

        if (dataManager != null)
            dataManager.Save();
    }
    private void LoadData()
    {
        if (volumeSlider == null || vibrationsText == null || dataManager == null)
            return;

        //volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        //vibrationsText.text = PlayerPrefs.GetString("Vibration");

        volumeSlider.value = dataManager.Volume;
        vibrationsText.text = dataManager.Vibrations.ToString();
    }
}
