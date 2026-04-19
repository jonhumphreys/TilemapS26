using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyDrop EnemyDrop;
    
    private int currentHealth;
    private int maximumHealth;
    
    void Start()
    {
        maximumHealth = GameParameters.EnemyMaximumHealth;
        currentHealth = maximumHealth;
    }
    
    public void ChangeHealth(int amount)
    {
        currentHealth = currentHealth + amount;
        
        if (currentHealth > maximumHealth)
            currentHealth = maximumHealth;
        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth == 0)
        {
            EnemyDrop.SpawnTileOnEnemyDeath();
            Destroy(gameObject);
        }
    }
}
