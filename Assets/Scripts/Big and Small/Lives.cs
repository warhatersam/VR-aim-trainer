using UnityEngine;

public class Lives: MonoBehaviour 
{
    public int lives = 3;
    public RandomSpawn spawn;
    public TargetBigThenSmall target;

    void OnEnable()
    {
        TargetBigThenSmall.TimeOut.AddListener(LoseLife);
    }
    void OnDisable()
    {
        TargetBigThenSmall.TimeOut.RemoveListener(LoseLife);
    } 
    public void LoseLife()
    {
        lives -= 1;
        if (lives <= 0) spawn.StopSpawning();
    }
    public void ResetLife()
    {
        if (!spawn.running) 
        {
            lives = 3;
        }
    }
}
