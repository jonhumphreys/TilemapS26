using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public PlayerAttack PlayerAttack;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerAttack.OnHitboxCollidedWithEnemy(collision);
        }
    }
}
