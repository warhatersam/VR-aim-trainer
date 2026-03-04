using UnityEngine;
using UnityEngine.UI;


public class RandomSpawn: MonoBehaviour
{
    public GameObject TargetPrefab;
    public float ClearanceRadius = 1f;
    public float SpawnFrequency = 1f;
    public LayerMask CollideMask;
    public float MaxTries = 10f;
    float NextTimeToSpawn;
    float StartTime;
    public float CurrentTime = 0f;
    public bool running = false;
    public Transform SpawnCenter;
    public float TargetSize = 2f;
    public Slider Sizeslider;
    public string savekey = "BigthenSmallSlider";
    public Score score;
    

    public void Start()
    {
        Sizeslider.onValueChanged.AddListener(OnsizeChanged);
        Sizeslider.value = PlayerPrefs.GetFloat(savekey, 1f);
        TargetSize = 1f * Sizeslider.value;
    }
    void OnsizeChanged(float value)
    {
        TargetSize = value * 1f;
        PlayerPrefs.SetFloat(savekey, value);
    }
    
    public void Update()
    {
        if (!running) return;
        CurrentTime = Time.time - StartTime;
        SpawnFrequency =  1f + 0.05f * Mathf.Pow(CurrentTime, 0.5f);
        if (Time.time >= NextTimeToSpawn)
        {
            Spawn();
            NextTimeToSpawn += 1/ SpawnFrequency;
            
        }
    }
    public void StartSpawning()
    {
        if (!running)
        {
            StartTime = Time.time;
            NextTimeToSpawn = StartTime + 2f;
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
    public void Spawn()
    {
        Vector3 center = SpawnCenter.position;
        for (int i = 0; i < MaxTries; i++)
        {
            float x = center.x + Random.Range(-15f, 15f);
            float y = center.y + Random.Range(-8f, 13f);
            float z = center.z;
            Vector3 pos = new Vector3(x, y, z);
            if (Physics.CheckSphere(pos, ClearanceRadius, CollideMask)) continue;
            Instantiate(TargetPrefab, pos, Quaternion.identity);
            return;
        }
    }
}
