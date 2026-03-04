using UnityEngine;
using UnityEngine.UI;

public class TrackingSpawn: MonoBehaviour
{
    public Transform SpawnCenter;
    public GameObject TargetPrefab;
    public LayerMask ColliderMask;
  

    public bool running = false;
    public float StartTime;
    public int MaxTargets = 6;
    public int MaxTries = 10;
    public int TargetsNum;
    public float ModeDuration = 30f;
    public float TargetSize = 0.08f;
    public float CurrentTime;
    private float spawnTime;
    public float y_bound = 5f;
    public float z_bound = 7f; 
    public Slider Sizeslider;
    public string savekey = "TrackingSlider";
    public TrackingScore score;
    

    public void Start()
    {
        Sizeslider.onValueChanged.AddListener(OnsizeChanged);
        Sizeslider.value = PlayerPrefs.GetFloat(savekey, 1f);
        TargetSize = 0.1f * Sizeslider.value;
    }
    void OnsizeChanged(float value)
    {
        TargetSize = value * 0.1f;
        PlayerPrefs.SetFloat(savekey, value);
    }


    

    public void StartSpawning()
    {
        if (!running) 
        {
            TargetsNum = 0;
            StartTime = Time.time + 2f;
            spawnTime = 0f;
        }
        running = true;
        Sizeslider.gameObject.SetActive(false);
        
    }
    public void StopSpawning()
    {
        running = false;
        score.ResetScore();
        Sizeslider.gameObject.SetActive(true);
    }
    public void Restart()
    {
        StopSpawning();
        StartSpawning();
    }
    public void Update()
    {
        if (!running) return;
        CurrentTime = Time.time - StartTime;
        if (CurrentTime >= 0f && TargetsNum < MaxTargets)
        {
            Spawn();
            TargetsNum += 1;
        }
        if (CurrentTime > ModeDuration)
        {
            StopSpawning();
        }
    }
    public void Despawned()
    {
        TargetsNum -= 1;
    }
    public void Spawn()
    {
        Vector3 center = SpawnCenter.position;
        for (int i=0; i<MaxTries; i++)
        {
            float x = center.x;
            float y = center.y + Random.Range(-y_bound,y_bound);
            float z = center.z + Random.Range(-z_bound,z_bound);
            Vector3 SpawningPosition = new Vector3(x,y,z);
            if (Physics.CheckSphere(SpawningPosition, TargetSize, ColliderMask)) continue;
            Instantiate(TargetPrefab, SpawningPosition, Quaternion.identity);
            return;
        }
    }
}
