using UnityEngine;
using TMPro;

public class TimeDisplay: MonoBehaviour
{
    public RandomSpawn spawnScript;
    public TMP_Text label;

    public void Update()
    {
        label.text = spawnScript.CurrentTime.ToString("0.00");
    }
}
