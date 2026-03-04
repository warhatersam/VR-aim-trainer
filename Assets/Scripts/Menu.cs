using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Menu: MonoBehaviour 
{
    public static float PitchOffset;
    public static float YawOffset;
    public static float RollOffset;
    public Slider PitchSlider;
    public Slider YawSlider;
    public Slider RollSlider;
    public string SaveKey = "WeaponIndex";

    int WeaponIndex = 0;
    string Key(string name)
    {
        return $"Weapon{WeaponIndex}_{name}";
    }
    
    public void Select(int index)
    {
        WeaponIndex = index;
        PitchSlider.value = PlayerPrefs.GetFloat(Key("Pitch"), 0f);
        YawSlider.value = PlayerPrefs.GetFloat(Key("Yaw"), 0f);
        RollSlider.value = PlayerPrefs.GetFloat(Key("Roll"), 0f);
        PitchOffset = PlayerPrefs.GetFloat(Key("Pitch"), 0f);
        YawOffset = PlayerPrefs.GetFloat(Key("Yaw"), 0f);
        RollOffset = PlayerPrefs.GetFloat(Key("Roll"), 0f);
        PlayerPrefs.SetInt(SaveKey, index);
        PlayerPrefs.Save();
    }
    void Start()
    {
        int Savedindex = PlayerPrefs.GetInt(SaveKey);
        Select(Savedindex);
        PitchSlider.onValueChanged.AddListener(OnPitchChanged);
        YawSlider.onValueChanged.AddListener(OnYawChanged);
        RollSlider.onValueChanged.AddListener(OnRollChanged);

    }
    void OnPitchChanged(float value)
    {
        // Debug.Log("pitch off set is"+ PitchOffset);
        PitchOffset = value;
        PlayerPrefs.SetFloat(Key("Pitch"), value);
        PlayerPrefs.Save();
    }
    void OnYawChanged(float value)
    {
        // Debug.Log("yaw off set is"+ YawOffset);
        YawOffset = value;
        PlayerPrefs.SetFloat(Key("Yaw"), value);
        PlayerPrefs.Save();
    }
    void OnRollChanged(float value)
    {
        RollOffset = value;
        PlayerPrefs.SetFloat(Key("Roll"), value);
        PlayerPrefs.Save();
    }
}    
