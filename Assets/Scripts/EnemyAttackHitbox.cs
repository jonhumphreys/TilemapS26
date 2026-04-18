using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    public EnemyAttack EnemyAttack;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnemyAttack.OnHitboxCollidedWithPlayer(collision);
        }
    }
}
