using UnityEngine;

public class SSHealth: MonoBehaviour 
{
    public float hp = 1f;
    public SphereSwitchSpawn sphereSwitchSpawn;
    public void Awake()
    {

        if (sphereSwitchSpawn == null)
        {
            sphereSwitchSpawn = FindFirstObjectByType<SphereSwitchSpawn>();
        }
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp < 0f) Destroy(gameObject);
        sphereSwitchSpawn.TargetsNum -= 1;

    }
    public void Despawn()
    {
        sphereSwitchSpawn.TargetsNum -= 1;
    }
}
