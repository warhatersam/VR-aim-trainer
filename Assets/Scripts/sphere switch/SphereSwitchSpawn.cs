using UnityEngine;
using UnityEngine.UI;

public class SphereSwitchSpawn: MonoBehaviour
{
    public Transform SpawnCenter;
    public GameObject TargetPrefab;
    public LayerMask ColliderMask;
  

    public bool running = false;
    public float StartTime;
    public int MaxTargets = 3;
    public int MaxTries = 10;
    public int TargetsNum;
    public float ModeDuration = 30f;
    public float TargetSize = 1f;
    public float CurrentTime;
    public Slider Sizeslider;
    public string savekey = "SphereSwitchSlider";
    public SphereSwitchScore score;
    

    public void Start()
    {
        Sizeslider.onValueChanged.AddListener(OnsizeChanged);
        Sizeslider.value = PlayerPrefs.GetFloat(savekey, 1f);
        TargetSize = 0.12f * Sizeslider.value;
    }
    void OnsizeChanged(float value)
    {
        TargetSize = value * 0.12f;
        PlayerPrefs.SetFloat(savekey, value);
    }

    public void StartSpawning()
    {
        if (!running) 
        {
            TargetsNum = 0;
            StartTime = Time.time + 2f;
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
        if (CurrentTime >= 0f && TargetsNum < MaxTargets )
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
            float x = center.x + Random.Range(-5f,5f);
            float y = center.y + Random.Range(-2f,2.5f);
            float z = center.z + Random.Range(-5f,5f);
            Vector3 SpawningPosition = new Vector3(x,y,z);
            if (Physics.CheckSphere(SpawningPosition, TargetSize, ColliderMask)) continue;
            Instantiate(TargetPrefab, SpawningPosition, Quaternion.identity);
            return;
        }
    }
}
