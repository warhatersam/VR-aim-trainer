using UnityEngine;

public class STHealth: MonoBehaviour 
{
    public float hp = 1f;
    public SixTargetsSpawn sixTargetsSpawn;
    public void Awake()
    {
        if (sixTargetsSpawn == null)
        {
            sixTargetsSpawn = FindFirstObjectByType<SixTargetsSpawn>();
        }

    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp < 0f) Destroy(gameObject);
        sixTargetsSpawn.TargetsNum -= 1;

    }
    public void Despawn()
    {
        sixTargetsSpawn.TargetsNum -= 1;
    }
}
