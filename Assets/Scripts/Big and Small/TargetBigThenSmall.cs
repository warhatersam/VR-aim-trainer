using UnityEngine;
using UnityEngine.Events;

public class TargetBigThenSmall: MonoBehaviour
{
    public Transform target;
    public float Spawntime;
    public float ExistingDuration = 8f;
    float size = 0f;
    public static UnityEvent TimeOut = new UnityEvent(); 
    public RandomSpawn spawn;

    void Awake()
    {
        Spawntime = Time.time;
        if (target == null) target = transform;
        target.localScale = Vector3.zero;
        if (spawn == null)
        {
            spawn = FindFirstObjectByType<RandomSpawn>();
        }
    }
    void Update()
    {
        if (!spawn.running) Destroy(gameObject);
        float k = spawn.TargetSize / ExistingDuration;
        float time = Time.time - Spawntime;
        if (time <= 0.5f *  ExistingDuration)
        {
            size = time * k;
        }
        else if (time < ExistingDuration)
        {
            size = spawn.TargetSize - time * k;
        }
        if (time >= ExistingDuration)
        {
            TimeOut.Invoke();
            Destroy(gameObject);
        }
        target.localScale = Vector3.one * size;
    }
}
