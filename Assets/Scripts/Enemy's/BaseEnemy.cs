using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private List<GameObject> pickups;
    private GameManager gameManager;
    public int scoreAmount;
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
            GameManager.Instance.AddScore(scoreAmount);
            Destroy(this.gameObject);
        }
    }
}
