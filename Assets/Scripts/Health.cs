using UnityEngine;
using UnityEngine.Events;
public class Health: MonoBehaviour 
{
    public float hp = 1f;
    public UnityEvent onDeath;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp < 0f) Die();

    }
    public void Die()
    {
        onDeath?.Invoke();
        Destroy(gameObject);
    }
}
