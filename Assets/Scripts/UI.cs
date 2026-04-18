using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TMP_Text HealthText;

    public void ShowHealth(int currentHealth, int maxHealth)
    {
        HealthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }
}
