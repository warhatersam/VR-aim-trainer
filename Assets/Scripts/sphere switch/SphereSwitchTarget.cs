using UnityEngine;

public class SphereSwitchTarget: MonoBehaviour 
{

    public SphereSwitchSpawn spawn;
    public Transform target;

    public void Awake()
    {
        if (spawn == null)
        {
            spawn = FindFirstObjectByType<SphereSwitchSpawn>();
        }
        target.localScale = Vector3.one * spawn.TargetSize;
    }
    public void Update()
    {
        if (!spawn.running)
        {
            spawn.Despawned();
            Destroy(gameObject);
        }
    }
}
