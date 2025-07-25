using UnityEngine;

public class Heath : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;

    private bool isDestroyed = false;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;
        
        if(hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        if (!isDestroyed)
        {
            hitPoints += amount;
        }
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }
}
