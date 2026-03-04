using UnityEngine;

public class TrackingTargets: MonoBehaviour 
{

    public TrackingSpawn TrackingSpawn;
    public Transform target;

    float NextStrafingTime = 0;
    float V_z = 0;
    float V_y = 0;
    public float Speed = 1.5f;
    Vector3 center;
    float Y_bound, Z_bound, upper_y, lower_y, upper_z, lower_z;

    public void Awake()
    {
        if (TrackingSpawn == null)
        {
            TrackingSpawn = FindFirstObjectByType<TrackingSpawn>();
        }
        target.localScale = Vector3.one * TrackingSpawn.TargetSize;
        Vector3 center = TrackingSpawn.SpawnCenter.position;
        Y_bound = TrackingSpawn.y_bound;
        Z_bound = TrackingSpawn.z_bound;
        upper_y = center.y + Y_bound;
        lower_y = center.y - Y_bound;
        upper_z = center.z + Z_bound;
        lower_z = center.z - Z_bound;
    }
    void Strafe()
    {
        V_y = Random.Range(0.6f * Speed, Speed) * (Random.value < 0.5f ? 1f : -1f);
        V_z = Random.Range(0.6f * Speed, Speed) * (Random.value < 0.5f ? 1f : -1f);
    }
    void Move()
    {
        target.Translate(Vector3.up * V_y * Time.deltaTime);
        target.Translate(Vector3.forward * V_z * Time.deltaTime);
    }
    public void Update()
    {   
        if (Time.time > NextStrafingTime)
        {
            Strafe();
            float StraingInterval = Random.Range(0.3f, 1f);
            NextStrafingTime = Time.time + StraingInterval;
        }
        float y = target.position.y;
        float z = target.position.z;
        
        if (y < lower_y || y > upper_y || z < lower_z || z > upper_z) Strafe();
        Move();
        if (!TrackingSpawn.running)
        {
            TrackingSpawn.Despawned();
            Destroy(gameObject);
        }

    }
}
