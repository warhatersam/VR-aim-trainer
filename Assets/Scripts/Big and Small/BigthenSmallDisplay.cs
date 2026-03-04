using UnityEngine;
using TMPro;
public class BigthenSmallDisplay: MonoBehaviour 
{
    public TMP_Text Scorelabel;
    public TMP_Text Timelabel;
    public TMP_Text PBlabel;
    public Score score;
    public RandomSpawn spawn;
    public Lives lives;
    public TMP_Text Liveslabel;



    public void Update()
    {
        Scorelabel.text = score.score.ToString("");
        Timelabel.text =  spawn.CurrentTime.ToString("0.00");
        Liveslabel.text = $"lives:{lives.lives}";
        PBlabel.text = $"Personal Best:{score.PB}";
        Debug.Log(spawn.CurrentTime);
        
    }
}
