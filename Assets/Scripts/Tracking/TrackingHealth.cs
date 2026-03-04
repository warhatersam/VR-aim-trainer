using UnityEngine;

public class TrackingHealth: MonoBehaviour 
{
    public float hp = 1f;
    public TrackingSpawn TrackingSpawn;
    public void Awake()
    {
        if (TrackingSpawn == null)
        {
            TrackingSpawn = FindFirstObjectByType<TrackingSpawn>();
        }

    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp < 0f) Destroy(gameObject);
        TrackingSpawn.TargetsNum -= 1;

    }
    public void Despawn()
    {
        TrackingSpawn.TargetsNum -= 1;
    }
}
