using UnityEngine;

public class TargetsSix: MonoBehaviour 
{

    public SixTargetsSpawn sixTargetsSpawn;
    public Transform target;

    public void Awake()
    {
        if (sixTargetsSpawn == null)
        {
            sixTargetsSpawn = FindFirstObjectByType<SixTargetsSpawn>();
        }
        target.localScale = Vector3.one * sixTargetsSpawn.TargetSize;
    }
    public void Update()
    {
        if (!sixTargetsSpawn.running)
        {
            sixTargetsSpawn.Despawned();
            Destroy(gameObject);
        }
    }
}
