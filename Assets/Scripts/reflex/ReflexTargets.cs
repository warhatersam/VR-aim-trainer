using UnityEngine;

public class ReflexTargets: MonoBehaviour 
{

    public ReflexSpawn reflexSpawn;
    public Transform target;
    private float SpawnTime;

    public void Awake()
    {
        if (reflexSpawn == null)
        {
            reflexSpawn = FindFirstObjectByType<ReflexSpawn>();
        }
        target.localScale = Vector3.one * reflexSpawn.TargetSize;
        SpawnTime = Time.time;
    }
    public void Update()
    {
        float time = Time.time - SpawnTime;
        if (!reflexSpawn.running || time > reflexSpawn.existTime)
        {
            reflexSpawn.Despawned();
            Destroy(gameObject);
        }

    }
}
