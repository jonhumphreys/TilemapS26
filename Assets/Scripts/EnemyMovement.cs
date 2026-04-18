using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.LowLevelPhysics2D;

public class EnemyMovement : MonoBehaviour
{
    public Transform DetectionPoint;
    public LayerMask PlayerLayerMask;
    public Animator Animator;
    public Rigidbody2D Rigidbody2D;

    private EnemyState currentState;
    private Transform playerTransform;
    
    public void Update()
    {
        CheckForPlayer();
        HandleCurrentState();
    }

    private void HandleCurrentState()
    {
        if (currentState == EnemyState.Chasing)
        {
            Chase();
        }
        else if (currentState == EnemyState.Attacking)
        {
            StopMoving();
        }
    }

    private void StopMoving()
    {
        Rigidbody2D.linearVelocity = Vector2.zero;
    }

    private void Chase()
    {
        FacePlayer();
        MoveTowardTarget(playerTransform);
    }
    
    private void MoveTowardTarget(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        Rigidbody2D.linearVelocity = direction * GameParameters.EnemyMoveSpeed;
    }

    private void FacePlayer()
    {
        bool isPlayerToTheRight = playerTransform.position.x > transform.position.x;
        bool isFacingLeft = false;
        if (transform.localScale.x == -1)
            isFacingLeft = true;

        if (isPlayerToTheRight && isFacingLeft)
        {
            Flip();
        }
        else if (!isPlayerToTheRight && !isFacingLeft)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = scale.x * -1;
        transform.localScale = scale;
    }

    private void CheckForPlayer()
    {
        // look for the player
        List<Collider2D> hits = Physics2D.OverlapCircleAll(DetectionPoint.position, GameParameters.EnemyDetectRange, PlayerLayerMask).ToList();

        // if the player isn't in range
        if (hits.Count == 0)
        {
            ChangeState(EnemyState.Idle);
            return;
        }
        
        playerTransform = hits[0].transform;
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        bool isInAttackRange = false;
        if (distanceToPlayer <= GameParameters.EnemyAttackRange)
            isInAttackRange = true;

        if (isInAttackRange)
        {
            ChangeState(EnemyState.Attacking);
        }
        else
        {
            ChangeState(EnemyState.Chasing);
        }
    }

    private void ChangeState(EnemyState state)
    {
        ExitCurrentAnimation();
        currentState = state;
        StartNewAnimation();
        print("Enemy State: " + currentState);
    }

    private void ExitCurrentAnimation()
    {
        SetAnimationForState(false);
    }

    private void StartNewAnimation()
    {
        SetAnimationForState(true);
    }

    private void SetAnimationForState(bool isOn)
    {
        if (currentState == EnemyState.Idle)
        {
            Animator.SetBool(GameParameters.EnemyAnimationIdleString, isOn);
        }
        else if (currentState == EnemyState.Chasing)
        {
            Animator.SetBool(GameParameters.EnemyAnimationChasingString, isOn);
        }
        else if (currentState == EnemyState.Attacking)
        {
            Animator.SetBool(GameParameters.EnemyAnimationAttackingString, isOn);
        }
    }
}
