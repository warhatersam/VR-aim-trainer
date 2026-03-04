using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PositionAdjustment: MonoBehaviour
{
    public static float xOffset;
    public static float yOffset;
    public static float zOffset;
    public Slider xSlider;
    public Slider ySlider;
    public Slider zSlider;
    public string SaveKey = "WeaponIndex";

    int WeaponIndex = 0;
    string Key(string name)
    {
        return $"Weapon{WeaponIndex}_{name}";
    }
    
    public void Select(int index)
    {
        WeaponIndex = index;
        xSlider.value = PlayerPrefs.GetFloat(Key("x"), 0f);
        ySlider.value = PlayerPrefs.GetFloat(Key("y"), 0f);
        zSlider.value = PlayerPrefs.GetFloat(Key("z"), 0f);
        xOffset = PlayerPrefs.GetFloat(Key("x"), 0f);
        yOffset = PlayerPrefs.GetFloat(Key("y"), 0f);
        zOffset = PlayerPrefs.GetFloat(Key("z"), 0f);
        
        PlayerPrefs.SetInt(SaveKey, index);
        PlayerPrefs.Save();
    }
    void Start()
    {
        int Savedindex = PlayerPrefs.GetInt(SaveKey);
        Select(Savedindex);
        xSlider.onValueChanged.AddListener(OnxChanged);
        ySlider.onValueChanged.AddListener(OnyChanged);
        zSlider.onValueChanged.AddListener(OnzChanged);

    }
    void OnxChanged(float value)
    {
        xOffset = value;
        PlayerPrefs.SetFloat(Key("x"), value);
        PlayerPrefs.Save();
    }
    void OnyChanged(float value)
    {
        yOffset = value;
        PlayerPrefs.SetFloat(Key("y"), value);
        PlayerPrefs.Save();
    }
    void OnzChanged(float value)
    {
        zOffset = value;
        PlayerPrefs.SetFloat(Key("z"), value);
        PlayerPrefs.Save();
    }
}
