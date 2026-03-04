using UnityEngine;
using UnityEngine.UI;

public class SphereSwitchScore: MonoBehaviour
{
    public SphereSwitchSpawn spawn;
    public float score = 0f;
    public GunHand gun;
    public Slider Sizeslider;
    public float PB = 0f;
    public float size = 1f;

    void Update()
    {
        size = Sizeslider.value;
        PB = PlayerPrefs.GetFloat(Key(size), 0f);
    }
    string Key(float size)
    {
        return $"SphereSwitch size{size}";
    }

    void OnEnable()
    {
        GunHand.Shot.AddListener(Descore);
        GunHand.Hit.AddListener(AddScore);
    }
    void OnDisable()
    {
        GunHand.Shot.RemoveListener(Descore);
        GunHand.Hit.RemoveListener(AddScore);
    }

    public void AddScore()
    {
        if (spawn.running) score += 10.5f;
    }
    public void Descore()
    {
        if (spawn.running) score -= 0.5f;
    }

    public void ResetScore()
    {
        if (!spawn.running) 
        {
            Debug.Log("scored reset");
            if (score > PB) PlayerPrefs.SetFloat(Key(size), score);
            score = 0f;
        }
    }
}
