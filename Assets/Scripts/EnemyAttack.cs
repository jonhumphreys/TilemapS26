using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Collider2D HitboxCollider;

    public void EnableHitbox()
    {
        HitboxCollider.enabled = true;
    }

    public void DisableHitbox()
    {
        HitboxCollider.enabled = false;
    }

    public void OnHitboxCollidedWithPlayer(Collider2D playerCollider)
    {
        DisableHitbox();
        PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
        playerHealth.ChangeHealth(GameParameters.EnemyDamage);
    }
}
