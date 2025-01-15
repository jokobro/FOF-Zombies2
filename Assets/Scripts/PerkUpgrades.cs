using UnityEngine;

public class PerkUpgrades : MonoBehaviour
{
    GameManager gameManager;
    private bool isSpeedColaBought;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void HandleBuyingSpeedCola()
    {
        if (GameManager.Instance.Points >= 1500)
        {
            PlayerController.Instance.walkSpeed = 12.6f;
            GameManager.Instance.Points = -1500f;
            isSpeedColaBought = true;
        }
    }

    public void HandleBuyingQuickRevive()
    {
        if (GameManager.Instance.Points >= 800)
        {

        }
    }
}
