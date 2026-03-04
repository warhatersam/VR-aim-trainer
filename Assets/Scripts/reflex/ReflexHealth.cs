using UnityEngine;

public class ReflexHealth: MonoBehaviour 
{
    public float hp = 1f;
    public ReflexSpawn sixTargetsSpawn;
    public void Awake()
    {
        if (sixTargetsSpawn == null)
        {
            sixTargetsSpawn = FindFirstObjectByType<ReflexSpawn>();
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
