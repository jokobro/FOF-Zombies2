using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour, IDamageable
{    
    [SerializeField] private List<GameObject> pickups;
    GameManager gameManager;
    public int pointsAmount;
    public float health;
    private NavMeshAgent agent = null;
    [SerializeField] private Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
           /* GameManager.Instance.AddScore(pointsAmount);*/
            Destroy(this.gameObject);
        }
    }
}
