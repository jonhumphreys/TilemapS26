using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator Animator;
    public Collider2D HitboxCollider;

    public void OnAttack(InputValue value)
    {
        if (IsAlreadyAttacking())
        {
            return;
        }
        
        Animator.SetBool("IsAttacking", true);
    }

    public bool IsAlreadyAttacking()
    {
        return Animator.GetBool("IsAttacking");
    }

    public void FinishAttacking()
    {
        Animator.SetBool("IsAttacking", false);
    }

    public void EnableHitbox()
    {
        HitboxCollider.enabled = true;
    }

    public void DisableHitbox()
    {
        HitboxCollider.enabled = false;
    }

    public void OnHitboxCollidedWithEnemy(Collider2D enemyCollider)
    {
        DisableHitbox();
        EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();
        enemyHealth.ChangeHealth(GameParameters.PlayerDamage);
    }
}