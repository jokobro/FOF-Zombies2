using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private List<GameObject> pickups;
    GameManager gameManager;
    public int pointsAmount;
    public float health;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
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
