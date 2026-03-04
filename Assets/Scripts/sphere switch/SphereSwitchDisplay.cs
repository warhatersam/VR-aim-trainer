using UnityEngine;
using TMPro;
public class SphereSwitchDisplay: MonoBehaviour 
{
    public TMP_Text Scorelabel;
    public TMP_Text Timelabel;
    public TMP_Text PBlabel;
    public SphereSwitchScore score;
    public SphereSwitchSpawn spawn;

    public void Update()
    {
        Scorelabel.text = score.score.ToString("");
        Timelabel.text = (spawn.ModeDuration - spawn.CurrentTime).ToString("0.00");
        PBlabel.text = $"Personal Best:{score.PB}";
        
    }
}
