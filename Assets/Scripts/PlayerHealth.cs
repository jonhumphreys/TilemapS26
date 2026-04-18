using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public UI UI;
    
    private int currentHealth;
    private int maximumHealth;
    
    void Start()
    {
        maximumHealth = GameParameters.PlayerMaximumHealth;
        currentHealth = maximumHealth;
        UI.ShowHealth(currentHealth, maximumHealth);
    }
    
    public void ChangeHealth(int amount)
    {
        currentHealth = currentHealth + amount;
        if (currentHealth > maximumHealth)
            currentHealth = maximumHealth;
        if (currentHealth < 0)
            currentHealth = 0;
        
        UI.ShowHealth(currentHealth, maximumHealth);
    }

}
