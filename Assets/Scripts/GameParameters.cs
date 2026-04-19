using UnityEngine;

public static class GameParameters
{
    public static float PlayerMoveSpeed = 5f;
    public static int PlayerMaximumHealth = 10;
    public static int PlayerDamage = -2;

    public static int EnemyMaximumHealth = 6;
    public static float EnemyMinimumSpawnDelay = 1f;
    public static float EnemyMaximumSpawnDelay = 3f;
    public static float EnemyDetectRange = 5f;
    public static float EnemyAttackRange = 1.5f;
    public static float EnemyMoveSpeed = 3f;
    public static float EnemyAttackCooldownSeconds = 1f;
    public static int EnemyDamage = -1;

    public static string EnemyAnimationIdleString = "IsIdle";
    public static string EnemyAnimationChasingString = "IsChasing";
    public static string EnemyAnimationAttackingString = "IsAttacking";
}
